using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AIController : Controller
{
    #region Varibles
    public enum AIState { Idle, Guard, Chase, Flee, Patrol, Attack, BacktoPost };

    /// <summary>
    /// The current State of this FSM.
    /// </summary>
    public AIState currentState;

    private float lastStateChangeTime;

    public GameObject target;
    #endregion
    // Start is called before the first frame update
    public override void Start()
    {
        //run the parents base
        base.Start();

        TargetPlayerOne();
    }

    // Update is called once per frame
    public override void Update()
    {
        // run the parents base
        base.Update();

        MakeDecisions();

    }

  

    /// <summary>
    /// Automatically make decisions about what to do based on current conditions
    /// </summary>
    public void MakeDecisions()
    {
        //Debug.Log("Making Decisions");
        if (target == null)
        {
            Debug.Log("Retargeting");
            TargetPlayerOne();
        }
        else
        {
            Seek(target);
        }
    }

    public void TargetPlayerOne()
    {
        Debug.Log("Attempting to Target");
        // If the GameManager exists
        if (GameManager.instance != null)
        {
            // And the array of players exists
            if (GameManager.instance.players != null)
            {
                // And there are players in it
                if (GameManager.instance.players.Count > 0)
                {
                    //Then target the gameObject of the pawn of the first player controller in the list
                    target = GameManager.instance.players[0].pawn.gameObject;

                    Debug.Log("Player Once Targeted");
                }
            }
        }
    }

    protected void TargetNearestTank()
    {
        // Get a list of all the tanks (pawns)
        Pawn[] allTanks = FindObjectsOfType<Pawn>();

        // Assume that the first tank is closest
        Pawn closestTank = allTanks[0];
        float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);

        // Iterate through them one at a time
        foreach (Pawn tank in allTanks)
        {
            // If this one is closer than the closest
            if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= closestTankDistance)
            {
                // It is the closest
                closestTank = tank;
                closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
            }
        }

        // Target the closest tank
        target = closestTank.gameObject;
    }

    public virtual void ChangeState(AIState newState) 
    {
        //Change the current state
        currentState = newState;

        //Log the time that this change happened.
       lastStateChangeTime = Time.time;
    }


    public void DoSeekState()
    {
        Seek(target);
    }

    public void Seek(Vector3 targetPosition)
    {
       //Rotate towards Target
        pawn.RotateTowards(targetPosition);

        //Move towards target
        pawn.MoveForward();
    }

    public void Seek (GameObject target)
    {
        //rotate towrds target
        Seek(target.transform.position);
    }

    public void Seek(Transform targetTransform)
    {
        Seek(target.transform.position);
    }

    public void Seek(Pawn targetPawn)
    {
        Seek(targetPawn.gameObject);
    }



}
