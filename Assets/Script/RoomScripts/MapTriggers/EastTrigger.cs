using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EastTrigger : MonoBehaviour
{

    public GameObject[] gridPrefabs;

    private float triggerLimit;

    public bool spawnAtAwake;
    private GameObject mapPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;
    private GameObject spawnedPickup;

    //This is to store the current location of a room so it can spwan the next one properly
    public Transform referencePoint;


    // Start is called before the first frame update

    public void Awake()

{
        
    mapPrefab = gridPrefabs[Random.Range(0, gridPrefabs.Length)];

     
}




    private void OnTriggerEnter(Collider other)
    {
       
       
        if (other.CompareTag("Player"))
        {
            if (triggerLimit == 0)
            {


                //If north or south it needs to change on the Z
                // + 385.7 for North
                // - 385.7 for South
                //float northSouth = 385.7f;

                //If East or West it needs to change on the X
                // + 292.6 if East
                // - 292.6 if West
                float eastWest = 292.6f;


                float spawnPointX = referencePoint.position.x + eastWest;
                float spawnPointY = referencePoint.position.y;
                float spawnPointZ = referencePoint.position.z;

                Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);

                Instantiate(mapPrefab, spawnPosition, transform.rotation);

             
                triggerLimit = 1;
                SelfDestruct();
            }
        }
    }

  

  

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           SelfDestruct();
        }
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
