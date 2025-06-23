using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToKitchen : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.GetClosestAvailableKitchen(transform.position);
        if (target == null)
        {
            return false;
        }
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.ReturnKitchen(target);
        return true;
    }
}
