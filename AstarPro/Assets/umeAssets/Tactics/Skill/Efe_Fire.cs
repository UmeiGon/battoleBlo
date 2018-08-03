using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Efe_Fire : SkillEffect
{
    int damageValue;
    protected override void Effect(UnitPack unit_pack)
    {
        unit_pack.ApplyEffect(x => x.ReciveDamage(damageValue));
    }
    public Efe_Fire(int damage_value)
    {
        damageValue = damage_value;
    }
}
