using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : Pickup
{
    public HealthPowerup powerup;

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

            //Spawns Explosion
            Instantiate(whatToSpawn, transform.position, transform.rotation);

            // Destroy this pickup
            Destroy(gameObject);

        }
    }
}
