using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    public float damageDone;
    public Pawn owner;
    public Transform whatToSpawn;

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        //If the object this projectile hit has a Health component
        Health otherHealth = other.gameObject.GetComponent<Health>();

        //Damage it if it has a Health component
        if (otherHealth != null)
        {
            otherHealth.TakeDamage(damageDone, owner);
        }

        //Destroy the projectile when it hits anything, even if it didn't do damage
        Instantiate(whatToSpawn, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
