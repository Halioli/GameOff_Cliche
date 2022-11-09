using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Serialized
    [SerializeField] int maxHealth = 10;
    [SerializeField] int minHealth = 0;
    
    // Protected
    protected bool canBeDamaged;
    protected bool canBeHealed;

    // Private
    private int health { get; set; }

    void Start()
    {
        health = maxHealth;
        canBeDamaged = true;
        canBeHealed = true;
    }

    public void RestoreHealthToMaxHealth() { health = maxHealth; }

    public void ReceiveDamage(int damageAmount)
    {
        if (canBeDamaged)
        {
            health -= damageAmount;

            if (health <= minHealth)
            {
                health = minHealth;
            }
        }
    }

    public void ReceiveHealth(int healthValueToAdd)
    {
        if (canBeHealed)
        {
            if ((health + healthValueToAdd) <= maxHealth)
            {
                health += healthValueToAdd;
            }
            else
            {
                RestoreHealthToMaxHealth();
            }
        }
    }

    public bool IsDead() { return health <= minHealth; }
}
