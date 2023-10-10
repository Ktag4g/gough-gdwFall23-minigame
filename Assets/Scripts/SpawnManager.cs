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

    public float BackgroundSpawnDelay = 0;
    public float BackgroundSpawnInterval = 15f;

    public GameObject obstacle;
    public GameObject[] bears;
    public GameObject[] crewPrefabs;
    public GameObject background;
    public static List<GameObject> crew = new List<GameObject>();

    void Start()
    {
        //Calls function at timed intervals
        InvokeRepeating("SpawnObstacle", obsSpawnDelay, obsSpawnInterval);
        InvokeRepeating("SpawnBear", bearSpawnDelay, bearSpawnInterval);

        InvokeRepeating("SpawnBackground", BackgroundSpawnDelay, BackgroundSpawnInterval);
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

        //Spawns bear
        Instantiate(bears[bearIndex], spawnPos, bears[bearIndex].transform.rotation);
    }

    public void SpawnCrewBear()
    {
        Vector3 spawnPos = new Vector3(-0.2f, -0.65f, (ScoreManager.BearCounter + 1) * -2f);

        //Spawns bear
        crew.Add(Instantiate(crewPrefabs[0], spawnPos, crewPrefabs[0].transform.rotation));
    }

    void SpawnBackground()
    {
        Vector3 spawnPos = new Vector3(0, 0, 281.9f);

        Instantiate(background, spawnPos, background.transform.rotation);
    }
}
