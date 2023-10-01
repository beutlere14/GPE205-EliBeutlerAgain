using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float currentHealth;
    public float maxHealth;


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

    public void Die (Pawn source)
    {
        Debug.Log(source.name + " killed " + gameObject.name + ".");
        Destroy(gameObject);
    }
}
