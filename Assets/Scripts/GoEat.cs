using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoEat : GAction
{
    public override bool PrePerform()
    {
        TableFood tableFood = gameObject.GetComponent<GAgent>().inventory.FindItemWithTag("TableFood").GetComponent<TableFood>();
        GWorld.Instance.ReturnTableFood(tableFood);
        
        target = GWorld.Instance.GetRandomAvailableTable();
        if (target == null)
        {
            return false;
        }
        gameObject.GetComponent<GAgent>().inventory.AddItem(target);
        Debug.Log("Mesa añadida al inventario: " + target.name + " con tag: " + target.tag);
        agent.SetDestination(target.transform.position);
        return true;
    }

    public override bool PostPerform()
    {
        //GWorld.Instance.ReturnTable(target);
        //GWorld.Instance.GetWorld().ModifyState("isEating", 1);
        //beliefs.ModifyState("isEating", 1);
        return true;
    }
}
