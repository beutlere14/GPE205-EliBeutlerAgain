using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornerPatrol: MonoBehaviour
{
    public Transform thisBlock;
    public Transform firstLocation;
    public Transform secondLocation;
    public Transform thirdLocation;
    public Transform fourthLocation;
    public Pawn owner;

    public float swapTime;
    public float longPathSwapTime;

    // Start is called before the first frame update

    public void Start()
    {
        thisBlock.position = firstLocation.position;

        swappingAgain();

    }
   

   public void swapping()
    {
        thisBlock.position = firstLocation.position;
        Debug.Log("Swap to 1");

        Invoke("swappingAgain", longPathSwapTime);
    }

    public void swappingAgain()
    {
        thisBlock.position = secondLocation.position;
        Debug.Log("Swap to 2");

        Invoke("swappingAgainAgain", swapTime);
    }

    public void swappingAgainAgain()
    {
        thisBlock.position = thirdLocation.position;
        Debug.Log("Swap to 3");

        Invoke("swappingAgainAgainAgain", longPathSwapTime);
    }

    public void swappingAgainAgainAgain()
    {
        thisBlock.position = fourthLocation.position;
        Debug.Log("Swap to 4");

        Invoke("swapping", swapTime);
    }
}
