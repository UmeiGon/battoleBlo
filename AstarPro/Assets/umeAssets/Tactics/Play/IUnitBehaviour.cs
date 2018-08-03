using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class SelectBehaviour {
    SelectBehaviour nextBehaviour;
    public  abstract void SetUp();
    public  abstract bool Update();
    public  abstract void End();
}
