using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efe_Heal : SkillEffect
{
    int healValue;
    protected override void Effect(UnitPack unit_pack)
    {
        unit_pack.ApplyEffect(x=>x.ReciveHeal(healValue));
    }
    public Efe_Heal(int heal_value)
    {
        healValue = heal_value;
    }
}
