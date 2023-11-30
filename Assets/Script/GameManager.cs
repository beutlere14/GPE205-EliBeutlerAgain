using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    #region Varibles
    /// <summary>
    /// The static instance of this class - there can only be one.
    /// </summary>
    public static GameManager instance;

    public List<PlayerController> players;

    public static bool inStartingArea;


    //Prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;
    public Transform playerSpawnTransform;
    public GameObject mapSpawner;

    public float killScore = 0;
    public float lives;

    #endregion Varibles

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        players = new List<PlayerController>();
    }


    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        // Spawn player controller at (0,0,0) with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity);

        // Spawn the pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation);

        //Get the PlayerController component and Pawn component
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        // Hook them up
        newController.pawn = newPawn;   

      
        
    }

    public void reload()
    {
        if (mapSpawner != null)
        {
     
                Instantiate(mapSpawner, Vector3.zero, Quaternion.identity);
      
            
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inStartingArea = false;
           


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
        inStartingArea = true;

        }
    }

    public void destroyGameManager()
    {
        Destroy(gameObject);
    }

}
