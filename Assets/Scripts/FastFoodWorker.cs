using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFoodWorker : GAgent
{
    new void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("clientOrdered", 1, false);
        goals.Add(s1, 7);

        SubGoal s2 = new SubGoal("isAttending", 1, false);
        goals.Add(s2, 5);

    }
}