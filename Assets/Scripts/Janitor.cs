﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janitor : GAgent
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("clean", 1, false);
        goals.Add(s1, 5);

        SubGoal s2 = new SubGoal("rested", 1, false);
        goals.Add(s2, 1);
        Invoke("GetTired", Random.Range(10,20));
    }

    void GetTired()
    {
        beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(10,20));
    }

}
