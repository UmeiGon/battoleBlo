using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Kearu, Fire, Figa
}

public static class SkillDataBase
{
    public static Skill GetSkill(this SkillType skill_type)
    {
        switch (skill_type)
        {
            case SkillType.Kearu:
                return new Skill(new CrossSelecting(5, 2), new Efe_Heal(10));
            case SkillType.Fire:
                return new Skill(new CrossSelecting(3, 1), new Efe_Fire(10));
            case SkillType.Figa:
                return new Skill(new CrossSelecting(5, 3), new Efe_Fire(25));
        }
        return null;
    }
}
