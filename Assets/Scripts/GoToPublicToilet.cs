using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToPublicToilet : GAction
{
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemovePublicToilet();
        if (target == null)
            return false;
        inventory.AddItem(target);
        GWorld.Instance.GetWorld().ModifyState("freePublicToilet", -1);
        return true;
    }

    public override bool PostPerform()
    {
        GWorld.Instance.AddPublicToilet(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("freePublicToilet", 1);
        beliefs.RemoveState("needRelief");
        beliefs.RemoveState("bursting");
        return true;
    }
}
