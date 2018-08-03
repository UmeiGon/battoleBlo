using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mover
{

    float moveSpeed = 3.0f;
    Unit myUnit;
    bool isMoving;
    public Mover(Unit _unit)
    {
        myUnit = _unit;
    }
    public void MoveToPoint(Point2 _point)
    {
        if (isMoving) return;
        PathCreater pathCre = CompornentUtility.FindCompornentOnScene<PathCreater>();
        var path = pathCre.GetPath(myUnit.pos, _point,myUnit.GetMaxUnitStatus.stepHeight);
        if (path!=null)
        {
            myUnit.pos = _point;
            myUnit.StartCoroutine(MoveRoutine(path));
        }
    }
    IEnumerator MoveRoutine(List<Point2> _path)
    {
        isMoving = true;
        foreach (var p in _path)
        {
            yield return myUnit.StartCoroutine(OneMove(p));
        }
        isMoving = false;
    }
    IEnumerator OneMove(Point2 next_point)
    {
        var bStage = CompornentUtility.FindCompornentOnScene<BattleStage>();
        var sub = bStage.GetBlockPosition(next_point) - myUnit.transform.position;
        float sec = 0;
        while (sec <= 1.0f)
        { 
            myUnit.transform.position += sub * Time.deltaTime * moveSpeed;
            sec += Time.deltaTime * moveSpeed;
            yield return null;
        }
    }
}
