using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialogue : InteractMaster
{
    [SerializeField] TutorialMessages tutorialMessages;
    [SerializeField] bool showOnce = true;

    private bool shownDialogue = false;

    public override void DoInteraction(PlayerManager playerManager)
    {
        if (showOnce && !shownDialogue)
        {
            playerManager.SetCanMove(false);

            tutorialMessages.SendMessage();
            
            shownDialogue = true;
        }
        else if (!showOnce)
        {
            playerManager.SetCanMove(false);

            tutorialMessages.SendMessage();
        }
    }
}
