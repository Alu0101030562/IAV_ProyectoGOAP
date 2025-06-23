using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GWorld
{
    private static readonly GWorld instance = new GWorld();
    private static WorldStates world;

    private static GameObject clientBeingServed;
    private static Queue<TableFood> tablesFood;
    private static List<GameObject> kitchens;
    private static List<GameObject> tables;
    
    //Quitar
    private static Queue<GameObject> toilets;
    private static Queue<GameObject> publicToilets;
    private static Queue<GameObject> puddles;


    static GWorld()
    {
        world = new WorldStates();
        
        tablesFood = new Queue<TableFood>();
        GameObject[] tbsFood = GameObject.FindGameObjectsWithTag("TableFood");
        foreach (GameObject tbFoodGo in tbsFood)
        {
            TableFood tbFood = tbFoodGo.GetComponent<TableFood>();
            if (tbFood != null)
            {
                tablesFood.Enqueue(tbFood);
            }
        }
        
        kitchens = new List<GameObject>();
        GameObject[] ktch = GameObject.FindGameObjectsWithTag("Kitchen");
        foreach (GameObject kitchen in ktch)
            kitchens.Add(kitchen);
        
        tables = new List<GameObject>();
        GameObject[] tbls =GameObject.FindGameObjectsWithTag("Table");
        foreach (GameObject tabGo in tbls)
        {
            tables.Add(tabGo);
        }
        
        toilets = new Queue<GameObject>();
        publicToilets = new Queue<GameObject>();
        puddles = new Queue<GameObject>();
        
        
        GameObject[] toils = GameObject.FindGameObjectsWithTag("Toilet");
        foreach (GameObject t in toils)
            toilets.Enqueue(t);
        if (toils.Length > 0)
            world.ModifyState("freeToilet", toils.Length);
        
        GameObject[] pubToils = GameObject.FindGameObjectsWithTag("PublicToilet");
        foreach (GameObject pub in pubToils)
            publicToilets.Enqueue(pub);
        if(pubToils.Length > 0)
            world.ModifyState("freePublicToilet", pubToils.Length);

        /*GameObject[] puds = GameObject.FindGameObjectsWithTag("Puddle");
        foreach (GameObject p in puds)
            puddles.Enqueue(p);
        if (puds.Length > 0)
            world.ModifyState("uncleanPuddle", puds.Length);*/

        Time.timeScale = 5;

    }

    private GWorld()
    {
    }

    public bool TryGetOrder(GameObject client)
    {
        if (clientBeingServed != null)
        {
            return false;
        }
        
        clientBeingServed = client;
        return true;
    }

    public GameObject RemoveOrder()
    {
        GameObject client = clientBeingServed;
        clientBeingServed = null;
        return client;
    }

    public TableFood GetTableFood()
    {
        if(tablesFood.Count == 0) return null;
        return tablesFood.Dequeue();
            
    }

    public void ReturnTableFood(TableFood tbFood)
    {
        tablesFood.Enqueue(tbFood);
    }

    public GameObject GetClosestAvailableKitchen(Vector3 refPosition)
    {
        if(kitchens.Count == 0) return null;
        GameObject closestKitchen = null;
        float closestDist = Single.PositiveInfinity;
        foreach (GameObject kitchen in kitchens)
        {
            float dist = Vector3.Distance(refPosition, kitchen.transform.position);
            if (dist < closestDist)
            {
                closestKitchen = kitchen;
                closestDist = dist;
            }
        }
        kitchens.Remove(closestKitchen);
        return closestKitchen;
    }

    public void ReturnKitchen(GameObject kitchen)
    {
        kitchens.Add(kitchen);
    }
    
    public GameObject GetRandomAvailableTable()
    {
        if (tables.Count == 0) return null;

        int randomIndex = UnityEngine.Random.Range(0, tables.Count);
        GameObject selectedTable = tables[randomIndex];
        tables.RemoveAt(randomIndex);
        return selectedTable;
    }
    
    public void ReturnTable(GameObject table)
    {
        tables.Add(table);
    }
    
    public void AddToilet(GameObject p)
    {
        toilets.Enqueue(p);
    }
    public GameObject RemoveToilet()
    {
        if (toilets.Count == 0) return null;
        return toilets.Dequeue();
    }

    public void AddPublicToilet(GameObject p)
    {
        publicToilets.Enqueue(p);
    }

    public GameObject RemovePublicToilet()
    {
        if(publicToilets.Count == 0) return null;
        return publicToilets.Dequeue();
    }
    
    public void AddPuddle(GameObject p)
    {
        puddles.Enqueue(p);
    }
    public GameObject RemovePuddle()
    {
        if (puddles.Count == 0) return null;
        return puddles.Dequeue();
    }

    public static GWorld Instance
    {
        get { return instance; }
    }

    public WorldStates GetWorld()
    {
        return world;
    }
}
