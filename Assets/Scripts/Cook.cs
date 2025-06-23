using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cook : GAgent
{
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("orderDelivered", 1, false);
        goals.Add(s1, 5);
        
        SubGoal s2 = new SubGoal("isAttending", 1, false);
        goals.Add(s2, 5);
        
        SubGoal s3 = new SubGoal("rested", 1, false);
        goals.Add(s3, 2);
        Invoke("GetTired", Random.Range(10,20));
        
        SubGoal s4 = new SubGoal("relief", 1, false);
        goals.Add(s4, 1);
        Invoke("NeedRelief", Random.Range(10, 20));
    }


    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(10,20));
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
