using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PathCreater : MonoBehaviour
{
    Dictionary<Point2, Node> nodes = new Dictionary<Point2, Node>();
    List<Node> openList = new List<Node>();
    public void CreateNodes(Dictionary<Point2, BattleBlock> _blocks)
    {
        foreach (var i in _blocks)
        {
            var point = i.Key;
            CreateNode(point,i.Value.Height);
        }
    }
    void CreateNode(Point2 _point, int _height)
    {
        nodes.Add(_point, new Node(_point, _height));
    }
    void ResetNodes()
    {
        openList.Clear();
        foreach (var n in nodes)
        {
            n.Value.ResetStatus();
        }
    }
    public List<Point2> GetPath(Point2 start_pos, Point2 end_pos,int can_step_height)
    {
        ResetNodes();
        nodes[start_pos].FirstOpen();
        bool isOpend = OpenPath(nodes[start_pos],end_pos,0,can_step_height);
        if (isOpend)
        {
            List<Point2> pathList = new List<Point2>();
            Node pathNode = nodes[end_pos];
            pathList.Add(pathNode.pos);
            while ((pathNode = pathNode.Parent) != null)
            {
                if (start_pos!=pathNode.pos)
                {
                    pathList.Add(pathNode.pos);

                }
            }

            pathList.Reverse();
            return pathList;
        }
        return null;
    }
    bool OpenPath(Node pivot_node, Point2 end_point, int _cost,int can_step_height)
    {
        var dirs = Point2.GetFourDir();
        foreach (var i in dirs)
        {
            if (!nodes.ContainsKey(pivot_node.pos + i)) continue;
            var node = nodes[pivot_node.pos + i];
            if (node.Open(pivot_node,can_step_height))
            {
                node.CulcGuess(end_point);
                node.realCost = _cost;
                openList.Add(node);
            }
        }
        pivot_node.Close();
        openList.Remove(pivot_node);
        Node nextNode = GetNextOpenNode();
        if (nextNode==null)
        {
            return false;
        }
        if (nextNode.pos == end_point)
        {
            return true;
        }
        else
        {
            return OpenPath(nextNode, end_point, nextNode.Parent.realCost + 1,can_step_height);
        }

    }
    Node GetNextOpenNode()
    {
        var node = openList.Where(x => x.SumCost == openList.Min(y => y.SumCost));
        if (node.Any())
        {
            return node.First();
        }
        else
        {
            return null;
        }
    }
}
