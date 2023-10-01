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

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        shooter = GetComponent<TankShooter>();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void MoveForward()
    {
        Debug.Log("Move Forward");
    }

    public override void MoveBackward() 
    {
        Debug.Log("Move Backward");
    }

    public override void RotateClockwise()
    {
        Debug.Log("Rotate Clockwise");
    }

    public override void RotateCounterClockwise()
    {
        Debug.Log("Rotate Counter-Clockwise");
    }

    public override void Shoot()
    {
        shooter.Shoot(shellPrefab, fireForce, damageDone, shellLifespan);
    }
}
