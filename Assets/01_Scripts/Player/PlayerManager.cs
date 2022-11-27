using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] PlayerInventory inventory;
    [SerializeField] PlayerMovement movement;
    [SerializeField] HUD gameHUD;

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
        else if (Input.GetKeyDown(KeyCode.O))
        {
            gameHUD.FadeToBalack();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            gameHUD.FadeToGame();
        }
    }

    public PlayerInventory GetPlayerInventory() { return inventory; }

    public void SetCanMove(bool _value) { movement.SetCanMove(_value); }

    public void SetCanJump(bool _value) { movement.SetCanJump(_value); }
}
