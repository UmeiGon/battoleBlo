using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Point2 pos;
    int height;

    Node parent;
    public Node Parent
    {
        get { return parent; }
    }
    NodeStatus nodeStatus = NodeStatus.None;
    public int realCost;
    int guessCost;
 
   
    public Node(Point2 _pos, int _height)
    {
        pos = _pos;
        height = _height;
    }
    //ステをリセット
    public void ResetStatus()
    {
        parent = null;
        nodeStatus = NodeStatus.None;
        realCost = 0;
        guessCost = 0;
    }
    public int SumCost
    {
        get { return realCost + guessCost; }
    }
    public void FirstOpen()
    {
        nodeStatus = NodeStatus.Open;
    }
    public bool Open(Node parent_node,int can_step_height)
    {
        if (nodeStatus != NodeStatus.None ||!CanStepHeight(parent_node, can_step_height)) return false;
        parent = parent_node;
        nodeStatus = NodeStatus.Open;
        return true;
    }
    public bool Close()
    {
        if (nodeStatus != NodeStatus.Open) return false;
        nodeStatus = NodeStatus.Closed;
        return true;
    }

    public void CulcGuess(Point2 end_point)
    {
        var diff = end_point - pos;
        diff = diff.ToAbs();
        guessCost = diff.GetSum();
    }
    bool CanStepHeight(Node parent_node, int can_step_height)
    {
        var sub =height-parent_node.height;
        return (sub<= can_step_height);
    }
}
