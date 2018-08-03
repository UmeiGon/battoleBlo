using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUtility {

	public static List<Point2> GetCrossPoint(Point2 pivot_point,int _range)
    {
        Point2 pivot = pivot_point;
        int moveRange = _range;
        var blocks=CompornentUtility.FindCompornentOnScene<BattleStage>().Blocks;
        var pointList = new List<Point2>();
        for (int i = pivot.x - moveRange; i <= pivot.x + moveRange; i++)
        {
            for (int k = pivot.y - moveRange; k <= pivot.y + moveRange; k++)
            {
                var point = new Point2(i, k);
                //十字チェック
                if (!IsInnerOnCross(point,pivot,moveRange)) continue;
                //blockがあるかチェック
                if (!blocks.ContainsKey(point)) continue;
                pointList.Add(point);
            }
        }
        return pointList;
    }
    public static bool IsInnerOnCross(Point2 point_1,Point2 point_2,int _range)
    {
        return (point_1 - point_2).AbsSum()<=_range;
    }
}
