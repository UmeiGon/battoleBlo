using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class UnitManager : SingleTon<UnitManager> {
    Dictionary<int, List<Unit>> unitDic;
    List<Unit> unitList=new List<Unit>();
    public Dictionary<int, List<Unit>> Units
    {
        get { return unitDic; }
    }

    void InitArmy()
    {
        unitDic = new Dictionary<int, List<Unit>>();
        //army(陣営)毎にunitのlistを作成
        foreach (var a in Enum.GetValues(typeof(Army)))
        {
            unitDic.Add((int)a, new List<Unit>());
        }
    }
    //unitが存在している陣営のみのlistを返す。
    public List<Army> GetArmyList()
    {
        List<Army> armyList=new List<Army>();
        foreach (var a in unitDic)
        {
            if(a.Value.Count>0)armyList.Add((Army)a.Key);
        }
        return armyList;
    }
    public List<Point2> GetStandingPoints()
    {
        List<Point2> pointList = new List<Point2>();
        foreach (var i in unitList)
        {
            pointList.Add(i.pos);
        }
        return pointList;
    }
    public List<Unit> GetStandingUnits(List<Point2> point_list)
    {
        List<Unit> retUnits=new List<Unit>();
        foreach (var p in point_list)
        {
            Unit unit;
            if(unit=unitList.Find(x => x.pos == p))
            {
                retUnits.Add(unit);
            }
        }
        return retUnits;
    }
    public void AddUnit(Unit _unit)
    {
        if (unitDic == null)
        {
            InitArmy();
        }
        unitDic[(int)_unit.Army].Add(_unit);
        unitList.Add(_unit);
    }
}
