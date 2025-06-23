using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFood : MonoBehaviour
{
    private Cook _cook;
    private GameObject _attendingSpot;
    private GameObject _attendedSpot;
    
    void Start()
    {  
        _cook = gameObject.GetComponentInChildren<Cook>();
        foreach (Transform t in transform)
        {
            switch (t.tag)
            {
                case "AttendingSpot":
                    _attendingSpot = t.gameObject;
                    break;
                case "AttendedSpot":
                    _attendedSpot = t.gameObject;
                    break;
            }
        }
    }

    public Cook GetCook()
    {
        return _cook;
    }

    public GameObject GetAttendingSpot()
    {
        return _attendingSpot;
    }

    public GameObject GetAttendedSpot()
    {
        return _attendedSpot;
    }
}
