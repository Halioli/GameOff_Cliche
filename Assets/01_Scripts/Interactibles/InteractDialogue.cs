using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialogue : InteractMaster
{
    [SerializeField] TutorialMessages tutorialMessages;

    public override void DoInteraction(PlayerManager playerManager)
    {
        playerManager.SetCanMove(false);

        tutorialMessages.SendMessage();
    }
}
