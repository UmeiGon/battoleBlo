using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlineMoveBehaviour : SelectBehaviour {
    public override void End()
    {
        throw new System.NotImplementedException();
    }

    public override void SetUp()
    {
        throw new System.NotImplementedException();
    }

    public override bool Update()
    {
        //if (PlayerInfo.Instance.IsOnline)
        //{
        //    if (unit.Army == PlayerInfo.Instance.team)
        //    {
        //        var point = UnitMove();
        //        if (!point.isEmpty)
        //        {
        //            //pointを通信で渡す関数
        //        }
        //        return point.isEmpty;
        //    }
        //    else
        //    {
        //        //通信でpointを持ってくる。
        //        //if (移動したら)
        //        //{
        //        //var point =ポイントを貰う関数
        //        //unit.MoveToPoint();
        //        //return point.isempty;
        //        //}
        //        //
        //    }
        //}
        //else
        //{
        //    UnitMove();
        //}
        return false;
    }
}
