using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Spawn variables
    public float obsSpawnDelay = 1;
    public float obsSpawnInterval = 0.3f;

    public float bearSpawnDelay = 5;
    public float bearSpawnInterval = 2f;

    public GameObject obstacle;
    public GameObject[] bears;

    void Start()
    {
        //Calls function at timed intervals
        InvokeRepeating("SpawnObstacle", obsSpawnDelay, obsSpawnInterval);
        InvokeRepeating("SpawnBear", bearSpawnDelay, bearSpawnInterval);
    }

    void SpawnObstacle()
    {
        //Assigns random position
        Vector3 spawnPos = new Vector3(Random.Range(-4, 4), Random.Range(0, 4), 30);

        //Spawns obstacle
        Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
    }

    void SpawnBear()
    {
        //Assigns random bear and position
        int bearIndex = Random.Range(0, bears.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-4, 4), Random.Range(0, 4), 30);

        //Spawns obstacle
        Instantiate(bears[bearIndex], spawnPos, bears[bearIndex].transform.rotation);
    }
}
