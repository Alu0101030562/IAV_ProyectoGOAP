using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOrder : GAction
{
    public override bool PrePerform()
    {
        if (GWorld.Instance.GetWorld().HasState("clientOrder"))
        {
            return false;
        }

        if (!GWorld.Instance.TryGetOrder(this.gameObject))
        {
            return false;
        }
        return true;
    }
    
    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("clientOrder", 1);
        return true;
    }
}