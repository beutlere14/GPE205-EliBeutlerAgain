using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    public GameObject shellPrefab;
    public float fireForce;
    public float damageDone;
    public float shellLifespan;
    protected TankShooter shooter;
    // Variable to hold our Mover
    protected Mover mover;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        shooter = GetComponent<TankShooter>();
        mover = GetComponent<TankMover>();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }

    public override void MoveForward()
    {
        //Debug.Log("Move Forward");
        if (mover != null)
        {
            mover.Move(transform.forward, moveSpeed);
        }
        else
        {
            Debug.LogWarning("Warning: No Mover in TankPawn.MoveForward()!");
        }
    }

    public override void MoveBackward() 
    {
        // Debug.Log("Move Backward");
        mover.Move(transform.forward, -moveSpeed);
    }

    public override void RotateClockwise()
    {
        // Debug.Log("Rotate Clockwise");
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        //Debug.Log("Rotate Counter-Clockwise");
        mover.Rotate(-turnSpeed);
    }

    public override void RotateTowards(Vector3 targetPosition)
    {
        // Find the vector to the target
        Vector3 vectorToTarget = targetPosition - transform.position;

        //Find the rotation to look down that vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);

        //Rotate closer to that vector, but don't rotate more than our turn speed allows in one frame.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    public override void Shoot()
    {
        shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifespan);
    }
}
