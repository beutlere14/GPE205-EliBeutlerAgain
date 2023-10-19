using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("Making Decisions");
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
