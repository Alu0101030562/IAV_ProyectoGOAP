using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOrderComplete : GAction
{
    public override bool PrePerform()
    {
        TableFood tableFood = GWorld.Instance.GetTableFood();
        if (tableFood == null)
        {
            return false;
        }

        target = tableFood.GetAttendedSpot();
        gameObject.GetComponent<GAgent>().inventory.AddItem(tableFood.gameObject);

        return true;
    }

    public override bool PostPerform()
    {
        TableFood tableFood = gameObject.GetComponent<GAgent>().inventory.FindItemWithTag("TableFood").GetComponent<TableFood>();
        Cook cook = tableFood.GetCook();
        cook.beliefs.ModifyState("orderRequested", 1);
        cook.inventory.AddItem(gameObject);
        return true;
    }
    
}
