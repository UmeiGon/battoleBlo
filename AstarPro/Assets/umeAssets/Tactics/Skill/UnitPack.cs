using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPack {
    List<Unit> unitList=new List<Unit>();
    public bool IsExist
    {
        get
        {
            return (unitList.Count > 0);
        }
    }
    public UnitPack(List<Unit> unit_list)
    {
        unitList = unit_list;
    }
    public void AddTarget(Unit _unit)
    {
        unitList.Add(_unit);
    }
    public void ApplyEffect(System.Action<Unit> unit_action)
    {
        foreach (var u in unitList)
        {
            unit_action(u);
        }
    }
}
