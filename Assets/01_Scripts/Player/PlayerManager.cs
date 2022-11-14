using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private HealthSystem healthSystem;

    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    void Update()
    {
        if (healthSystem.IsDead())
        {
            Debug.Log("YOU DIED");
            healthSystem.RestoreHealthToMaxHealth();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            healthSystem.ReceiveDamage(5);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            healthSystem.ReceiveHealth(5);
        }
    }
}
