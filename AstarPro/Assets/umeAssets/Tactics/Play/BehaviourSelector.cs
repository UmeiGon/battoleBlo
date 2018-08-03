using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourSelector : MonoBehaviour
{
    SelectBehaviour unitBehaviour;
    // Use this for initialization
    private void Awake()
    {
        CompornentUtility.FindCompornentOnScene<SetUpManager>().AddSetUpAction(SetUp);
        StartCoroutine(BehaviourRoutine());
    }
    void SetUp()
    {
        var unit = CompornentUtility.FindCompornentOnScene<UnitSelector>().ActivUnit;
        unitBehaviour = new MoveBehaviour(unit);
        unitBehaviour.SetUp();
    }
    void BehaviourSetUp()
    {
        TurnManager.Instance.NextTurn();
        var unit = CompornentUtility.FindCompornentOnScene<UnitSelector>().ActivUnit;
        if (unit.Army == PlayerInfo.Instance.team)
        {
            unitBehaviour = new MoveBehaviour(unit);
        }
        else
        {

        }
        unitBehaviour.SetUp();

    }
    // Update is called once per frame
    IEnumerator BehaviourRoutine()
    {
        while (unitBehaviour == null) { yield return null; }
        while (true)
        {
            if (unitBehaviour.Update())
            {
                unitBehaviour.End();
                BehaviourSetUp();
            }
            yield return null;
        }
    }
}
