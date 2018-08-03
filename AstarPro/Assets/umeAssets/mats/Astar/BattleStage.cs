using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//single
public class BattleStage : MonoBehaviour
{

    Dictionary<Point2, BattleBlock> blocks = new Dictionary<Point2, BattleBlock>();
    public Dictionary<Point2, BattleBlock> Blocks
    {
        get { return blocks; }
    }

    public void AddBlock(Point2 _point, BattleBlock battle_block)
    {
        blocks.Add(_point, battle_block);
    }
    public bool IsThereBlock(Point2 _point)
    {
        return blocks.ContainsKey(_point);
    }
    public Vector3 GetBlockPosition(Point2 _point)
    {
        return blocks[_point].transform.position;
    }
}
