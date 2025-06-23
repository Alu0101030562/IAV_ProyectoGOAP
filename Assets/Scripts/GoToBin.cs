using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToBin : GAction
{
    public override bool PrePerform()
    {
        GameObject tableGO = gameObject.GetComponent<GAgent>().inventory.FindItemWithTag("Table");
        if (tableGO == null)
        {
            Debug.LogWarning(name + " no tiene mesa en su inventario para devolver.");
            return false;
        }
        else
        {
            Debug.Log(name + " devuelve la mesa: " + tableGO.name);
            GWorld.Instance.ReturnTable(tableGO);
            return true;
        }
        //GWorld.Instance.ReturnTable(tableGO);
        //return true;
    }

    public override bool PostPerform()
    {
        return true;
    }
}
