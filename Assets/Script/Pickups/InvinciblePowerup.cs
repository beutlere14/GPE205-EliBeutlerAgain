using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]


public class InvinciblePowerup : Powerup
{
  


    public override void Apply(PowerupManager target)
    {
        //The goal is to change the players color to purple while this is active
        Debug.Log("Invincible");

        // Apply Health Changes
        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth != null)
        {
            targetHealth.cantLoseHealth = true;
            targetHealth.Invincible();
            
        }




    }

    public override void Remove(PowerupManager target)
    {
        Debug.Log("No Longer Invincible");
        //This one has a duration
        Health targetHealth = target.GetComponent<Health>();

        if (targetHealth != null)
        {
            targetHealth.cantLoseHealth = false;

        }
    }
}
