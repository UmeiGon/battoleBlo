using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TurnManager : SingleTon<TurnManager>
{
    Turn<Army> turn = new Turn<Army>();
    private void Start()
    {
        SetUpTurn();
    }
    private void SetUpTurn()
    {
        var unitManager = CompornentUtility.FindCompornentOnScene<UnitManager>();
        turn.SetList(unitManager.GetArmyList());
    }
    //新しい陣営のunitが追加されたときなどに更新
    public void ReloadTurnList()
    {
        SetUpTurn();
    }
    public Army NextTurn()
    {
        return turn.NextTurn();
    }
    public Army CurrentTurn
    {
        get{ return turn.CurrentTurn; }
    }
}
