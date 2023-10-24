using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPointSwap : MonoBehaviour
{
    public Transform thisBlock;
    public Transform firstLocation;
    public Transform secondLocation;
    public Pawn owner;

    public float swapTime;

    // Start is called before the first frame update

    public void Start()
    {
        thisBlock.position = firstLocation.position;

        Invoke("swappingAgain", swapTime);

    }
    public void OnTriggerStay(Collider other)
    {
        Debug.Log("eventTriggered");
        if (thisBlock.position == firstLocation.position)
        {
            thisBlock.position = secondLocation.position;

            Debug.Log("Swap to 2");
        }
        else
        {
            thisBlock.position = firstLocation.position;
            Debug.Log("Swap to 1");
        }

    }

   public void swapping()
    {
        thisBlock.position = firstLocation.position;
        Debug.Log("Swap to 1");

        Invoke("swappingAgain", swapTime);
    }

    public void swappingAgain()
    {
        thisBlock.position = secondLocation.position;
        Debug.Log("Swap to 2");

        Invoke("swapping", swapTime);
    }
}
