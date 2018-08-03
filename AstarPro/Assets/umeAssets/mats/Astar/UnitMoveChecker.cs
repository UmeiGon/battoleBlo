using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveChecker : MonoBehaviour
{
    BattleStage battleStage;
    PathCreater pathCreater;
    private void Awake()
    {
        battleStage = CompornentUtility.FindCompornentOnScene<BattleStage>();
        pathCreater = CompornentUtility.FindCompornentOnScene<PathCreater>();
    }
    public List<Point2> GetCanMovePoint(Unit _unit)
    {
        List<Point2> standingList = CompornentUtility.FindCompornentOnScene<UnitManager>().GetStandingPoints();
        List<Point2> canMovePoints = new List<Point2>();
        Point2 pivot = _unit.pos;
        int moveRange = _unit.GetUnitStatus.moveRange;
        var crossPoints=StageUtility.GetCrossPoint(pivot,moveRange);
        foreach (var point in crossPoints)
        {
            //既にunitがいた場合continue
            if (standingList.Contains(point)) continue;
            //たどり着けるかチェック
            var pathList = pathCreater.GetPath(_unit.pos, point, _unit.GetUnitStatus.stepHeight);
            if (pathList == null) continue;
            //unitの設定歩数で行けるかチェック
            if (pathList.Count > moveRange) continue;
            canMovePoints.Add(point);
        }
        return canMovePoints;
    }
}
