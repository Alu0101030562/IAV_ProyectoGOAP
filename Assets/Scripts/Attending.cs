using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attending : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
