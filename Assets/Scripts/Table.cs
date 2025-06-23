using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    private GameObject _eatSpot;
    
    void Start()
    {  
        foreach (Transform t in transform)
        {
            switch (t.tag)
            {
                case "eatSpot":
                    _eatSpot = t.gameObject;
                    break;
            }
        }
    }

    public GameObject GetEatSpot()
    {
        return _eatSpot;
    }
}