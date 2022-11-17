using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] PlayerInventory inventory;

    private HealthSystem healthSystem; // change

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

    public PlayerInventory GetPlayerInventory() { return inventory; }
}
