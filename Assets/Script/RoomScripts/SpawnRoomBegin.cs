using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoomBegin : MonoBehaviour
{

    public GameObject[] gridPrefabs;



    public bool spawnAtAwake;
    private GameObject mapPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;
    private GameObject spawnedPickup;


    // Start is called before the first frame update

    public void Awake()

    {
        mapPrefab = gridPrefabs[Random.Range(0, gridPrefabs.Length)];

        if (spawnAtAwake == true)
        {
            spawnedPickup = Instantiate(mapPrefab, transform.position, Quaternion.identity) as GameObject;
        }

    }


  
}

