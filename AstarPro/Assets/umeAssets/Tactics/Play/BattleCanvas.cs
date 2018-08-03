using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleCanvas : SingleTon<BattleCanvas>
{
    [SerializeField] Text intelText;
    [SerializeField] Text atkText;
    [SerializeField] Text helthText;
    [SerializeField] Text manaText;
    Unit selectingUnit;
    public void OnActive(Unit _unit)
    {
        gameObject.SetActive(true);
        selectingUnit = _unit;
        ApplyStatus(_unit);
    }
    public void OffActive()
    {
        gameObject.SetActive(false);
    }
    void ApplyStatus(Unit _unit)
    {
        intelText.text = "" + _unit.GetUnitStatus.intel;
        atkText.text = "" + _unit.GetUnitStatus.atk;
        helthText.text = "" + _unit.GetUnitStatus.helth;
        manaText.text = "" + _unit.GetUnitStatus.mana;
    }
}
