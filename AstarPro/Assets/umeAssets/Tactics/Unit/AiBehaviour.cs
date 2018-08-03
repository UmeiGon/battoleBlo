using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviour : SelectBehaviour
{
    Unit unit;
    public override void End()
    {
    }

    public override void SetUp()
    {
    }

    public override bool Update()
    {
        return false;
    }
    AiBehaviour(Unit _unit)
    {
        unit = _unit;
    }
}
