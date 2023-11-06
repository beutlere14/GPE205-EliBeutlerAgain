using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPickup : Pickup
{
    public SpeedPowerup powerup;

    //Allows the explosion effect to be spawned
    public Transform whatToSpawn;

    public override void OnTriggerEnter(Collider other)
    {
        // variable to store other object's PowerupController - if it has one
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        // If the other object has a PowerupController
        if (powerupManager != null)
        {
            // Add the powerup
            powerupManager.Add(powerup);

            // This is used for spawning explosion mainly. Wont spawn anything if nothing is selected
            if (whatToSpawn != null)
            {
                Instantiate(whatToSpawn, transform.position, transform.rotation);
            }

            // Destroy this pickup
            Destroy(gameObject);

        }
    }
}
