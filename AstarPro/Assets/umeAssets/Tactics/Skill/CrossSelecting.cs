using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSelecting : SelectingTargetType
{
    int effectRange;
    int targetRange;
    public override List<Point2> Selecting(Unit _user,KeyCode _key)
    {
        LightPanelPopper.Instance.AllActiveOff();

        List<Point2> returnPoints = new List<Point2>();
        var redPoint = RightClickRayShot.GetMouseRayHitObject<BlockPointGetter>();
        if (redPoint == null)
        {
            return returnPoints;
        }
        var points=StageUtility.GetCrossPoint(redPoint.point,effectRange);
        foreach (var p in points)
        {
            LightPanelPopper.Instance.ActiveOn(p,Color.red);
        }
        var pointGetter = RightClickRayShot.GetMouseRayHitObject<BlockPointGetter>(_key);
        if (pointGetter != null)
        {
            returnPoints = StageUtility.GetCrossPoint(pointGetter.point,effectRange);
        }
        return returnPoints;
    }
    public CrossSelecting(int target_range,int effect_range)
    {
        targetRange = target_range;
        effectRange = effect_range;
    }
}
