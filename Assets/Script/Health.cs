using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float currentHealth;
    public float maxHealth;

    //Allows the explosion effect to be spawned
    public Transform whatToSpawn;

    //Delay so the player can see their own explosion before they die fully
    public float deathDelay;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    /// <summary>
    /// Subtract incoming damage from current health.
    /// </summary>
    /// <param name="amount">The amount of damage that was received.</param>
    /// <param name="source">the Pawn that fired the projectile.</param>
   public void TakeDamage(float amount, Pawn source)
    {
        currentHealth = currentHealth - amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log(source.name + " did " + amount + " damage to " + gameObject.name + ".");

        if (currentHealth <= 0)
        {
            Die(source);
        }
    }


    public void Heal(float amount, Pawn source)
    {
        currentHealth = currentHealth + amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log(source.name + " healed " + amount + " points to " + gameObject.name + ".");
    }

    public void Die (Pawn source)
    {
        Debug.Log(source.name + " killed " + gameObject.name + ".");
        //When a tank dies it spawns an explosion and set timer for it to go off
        Explode();
        //Destroy(gameObject);
    }

    void Explode()
    {
        //Spawns Explosion
        Instantiate(whatToSpawn, transform.position, transform.rotation);
        //Creates a delay equal to deathDelay varible
        Invoke("TrueDead", deathDelay);
    }

    private void TrueDead()
    {
        //Destroys object after deathDelay has completed.
        Destroy(gameObject);
    }

}
