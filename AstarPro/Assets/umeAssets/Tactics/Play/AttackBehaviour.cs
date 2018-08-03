using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : SelectBehaviour
{
    Unit unit;
    Skill skill;
    public AttackBehaviour(Unit _unit)
    {
        unit = _unit;
    }
    public override void End()
    {
        BattleCanvas.Instance.OffActive();
    }

    public override void SetUp()
    {
        BattleCanvas.Instance.OnActive(unit);
        skill = SkillDataBase.GetSkill(SkillType.Fire);

    }

    public override bool Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            skill = SkillDataBase.GetSkill(SkillType.Fire);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            skill = SkillDataBase.GetSkill(SkillType.Figa);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            skill = SkillDataBase.GetSkill(SkillType.Kearu);
        }
        return skill.Update(unit);
    }
}