using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : GAction
{
    public override bool PrePerform()
    {
        return true;
    }
    
    public override bool PostPerform()
    {
        GameObject client = GWorld.Instance.RemoveOrder();
        client.GetComponent<GAgent>().beliefs.ModifyState("orderCompleted", 1);
        GWorld.Instance.GetWorld().ModifyState("clientOrder", -1);
        gameObject.GetComponent<GAgent>().beliefs.ModifyState("isAttending", -1);
        return true;
    }
}
