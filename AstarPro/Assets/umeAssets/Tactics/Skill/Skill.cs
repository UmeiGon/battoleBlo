using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    SelectingTargetType selectType;
    SkillEffect effect;
    public Skill(SelectingTargetType select_type, SkillEffect _effect)
    {
        selectType = select_type;
        effect = _effect;
    }
    public bool Update(Unit _unit)
    {
        var points = selectType.Selecting(_unit,KeyCode.Mouse0);
        if (effect.Effect(points))
        {
            Debug.Log("aaaaa");
            return true;
        }
        else
        {
            return false;
        }
    }
}
