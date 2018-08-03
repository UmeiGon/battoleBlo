using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBlock
{
    int height;
    public int Height
    {
        get { return height; }
    }
    public Transform transform
    {
        get;
        private set;
    }
    public BattleBlock(int _height, Transform _transform)
    {
        height = _height;
        transform = _transform;
    }
}
