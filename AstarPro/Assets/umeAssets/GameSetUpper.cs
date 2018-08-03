using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetUpper : MonoBehaviour {
  
   
    // Use this for initialization
    void Start () {
        var sc=CompornentUtility.FindCompornentOnScene<StageCreater>();
        sc.CreateStage();
        var bs = CompornentUtility.FindCompornentOnScene<BattleStage>();
        CompornentUtility.FindCompornentOnScene<PathCreater>().CreateNodes(bs.Blocks);
       
    }
    
    private void Update()
    {
            
    }
}
