using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillEffect
{
    protected abstract void Effect(UnitPack unit_pack);
    public bool Effect(List<Point2> p_list)
    {
        var units = UnitManager.Instance.GetStandingUnits(p_list);
        var unitPack=new UnitPack(units);
        if (unitPack.IsExist)
        {
            Effect(unitPack);
        }
        return unitPack.IsExist;
    }
}
