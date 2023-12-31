using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


public class SpeedPowerup : Powerup
{
    //This will remember the targets speed before and after the speed boost so it can reset it.
    private float baseSpeed;
    public float speedMultiplier = 3;

    public override void Apply(PowerupManager target)
    {
        //The goal is to change the players color to purple while this is active
        Debug.Log("SpeedBoost");

        TankPawn targetTankPawn = target.GetComponent<TankPawn>();

        //Apply Speed Changes
        if (targetTankPawn != null)
        {
            //seting the default speed
            baseSpeed = targetTankPawn.moveSpeed;

            targetTankPawn.moveSpeed = baseSpeed + targetTankPawn.defaultSpeed + targetTankPawn.defaultSpeed + targetTankPawn.defaultSpeed;
        }


    }

    public override void Remove(PowerupManager target)
    {
        // this should have a pretty low duration
        Debug.Log("No More Ka-Chow");
        //This one has a duration
        TankPawn targetTankPawn = target.GetComponent<TankPawn>();

        //Apply Speed Changes
        if (targetTankPawn != null)
        {
            //seting the speed back to normal default speed
            targetTankPawn.moveSpeed = targetTankPawn.moveSpeed - targetTankPawn.defaultSpeed - targetTankPawn.defaultSpeed - targetTankPawn.defaultSpeed;
        }
    }
}
