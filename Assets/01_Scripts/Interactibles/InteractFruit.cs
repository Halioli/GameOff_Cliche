using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractFruit : InteractMaster
{
    public override void DoInteraction(PlayerManager playerManager)
    {
        //base.DoInteraction();

        playerManager.GetPlayerInventory().AddFruits(1);
        Debug.Log("ADDED FRUIT");

        Destroy(gameObject);
    }
}
