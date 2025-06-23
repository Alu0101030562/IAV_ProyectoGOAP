using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : GAgent
{
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("readyToOrder", 1, true);
        goals.Add(s1, 3);
        
        SubGoal s2 = new SubGoal("isAttended", 1, true);
        goals.Add(s2, 5);
        
        SubGoal s3 = new SubGoal("isEating", 1, true);
        goals.Add(s3, 7);
        
        SubGoal s4 = new SubGoal("isHome", 1, true);
        goals.Add(s4, 9);
        
        SubGoal s5 = new SubGoal("relief", 1, false);
        goals.Add(s5, 5);
        Invoke("NeedRelief", Random.Range(10, 20));
        
    }
    
    void NeedRelief()
    {
        beliefs.ModifyState("needRelief", 0);
        Invoke("Bursting", 10);
        Invoke("NeedRelief", Random.Range(20, 30));
    }
    void Bursting()
    {
        if (beliefs.HasState("needRelief"))
            beliefs.ModifyState("bursting", 0);
    }
}
