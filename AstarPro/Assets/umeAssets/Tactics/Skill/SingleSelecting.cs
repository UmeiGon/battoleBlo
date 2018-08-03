using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSelecting : SelectingTargetType
{
    int targetRange;
    public override List<Point2> Selecting(Unit _user, KeyCode _key)
    {
        var pointGetter = RightClickRayShot.GetMouseRayHitObject<BlockPointGetter>(_key);
        if (!pointGetter) return new List<Point2>();
        if (!StageUtility.IsInnerOnCross(_user.pos, pointGetter.point,targetRange)) return new List<Point2>();
        return new List<Point2>() {pointGetter.point };

    }
    public SingleSelecting(int target_range)
    {
        targetRange = target_range;
    }
}
