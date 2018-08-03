using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] Army army;
    public Army Army { get { return army; } }
    [SerializeField]UnitStatus unitStatus;
    public UnitStatus GetUnitStatus{get { return unitStatus; }}
    UnitStatus maxUnitStatus;
    public UnitStatus GetMaxUnitStatus {get{ return maxUnitStatus; } }

    Mover mover;
    public Point2 pos;
    public void MoveToPoint(Point2 _point)
    {
        mover.MoveToPoint(_point);
    }
    private void Awake()
    {
        mover = new Mover(this);
        maxUnitStatus = unitStatus;
        CompornentUtility.FindCompornentOnScene<UnitManager>().AddUnit(this);
        CompornentUtility.FindCompornentOnScene<SetUpManager>().AddSetUpAction(SetUp);
    }
    void SetUp()
    {
        transform.position = CompornentUtility.FindCompornentOnScene<BattleStage>().GetBlockPosition(pos);
    }
    void Death()
    {

    }
    public void ReciveDamage(int _value)
    {
        if (LimitValue.IsNegative(_value)) return;
        unitStatus.helth -= _value;
        if (unitStatus.helth<=0)
        {
            //Destroy(gameObject);
        }
    }
    public void ReciveHeal(int _value)
    {
        if (LimitValue.IsNegative(_value)) return;
        unitStatus.helth += _value;
        if (unitStatus.helth>maxUnitStatus.helth)
        {
            unitStatus.helth = maxUnitStatus.helth;
        }
    }
}
