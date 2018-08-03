using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SetUpManager : MonoBehaviour {
    List<Action> SetUpActions=new List<Action>();
    bool wasInit;
	// Use this for initialization
	public void AddSetUpAction(Action _action)
    {
        SetUpActions.Add(_action);
    }
    private void Update()
    {
        if (wasInit) return;
        foreach (var i in SetUpActions)
        {
            i();
        }
        wasInit = true;
    }
}
