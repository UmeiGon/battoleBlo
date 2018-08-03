using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour
{
    TurnManager turnManager;
    UnitManager unitManager;
    public Unit ActivUnit
    {
        get { return unitManager.Units[(int)turnManager.CurrentTurn][0];  }
    }

    // Use this for initialization
    void Start()
    {
        turnManager = CompornentUtility.FindCompornentOnScene<TurnManager>();
        unitManager = CompornentUtility.FindCompornentOnScene<UnitManager>();
    }
}
