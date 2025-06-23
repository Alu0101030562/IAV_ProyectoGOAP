using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public int initialUnits;
    public float spawnRate;
    public float spawnRateDeviation;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initialUnits; i++)
        {
            Instantiate(prefab, this.transform.position, Quaternion.identity);
        }

        Invoke("SpawnPrefab", spawnRate);
    }

    void SpawnPrefab()
    {
        Instantiate(prefab, this.transform.position, Quaternion.identity);
        Invoke("SpawnPrefab", Random.Range(spawnRate - spawnRateDeviation, spawnRate + spawnRateDeviation));
    }
}