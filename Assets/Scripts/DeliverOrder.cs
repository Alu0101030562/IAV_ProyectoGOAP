using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverOrder : GAction
{
    public override bool PrePerform()
    {
        return true;
    }

    public override bool PostPerform()
    {
        gameObject.GetComponent<GAgent>().beliefs.ModifyState("orderRequested", -1);
        GameObject clientGo = gameObject.GetComponent<GAgent>().inventory.FindItemWithTag("Client");
        gameObject.GetComponent<Cook>().inventory.RemoveItem(clientGo);
        Client client = clientGo.GetComponent<Client>();
        client.beliefs.ModifyState("hasOrder", 1);
        return true;
    }
}
