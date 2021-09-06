using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitSpawn : MonoBehaviour
{

    public GameObject[] shit;

    //Límites de Spawn
    private float limit = 380;
    private Vector3 spawnPos;

    //Invoke
    private float delay = 2;
    private float spawnRate = 1;

    void Start()
    {
        InvokeRepeating("Spawning", delay, spawnRate);
    }

    
    void Update()
    {
          
    }

    void Spawning()
    {
        spawnPos = new Vector3(Random.Range(-limit, limit), 1, Random.Range(-limit, limit));

        Instantiate(shit[Random.Range(0, 3)], spawnPos, shit[0].transform.rotation);
    }

    
}

