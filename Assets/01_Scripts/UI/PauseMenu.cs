using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsMenuGameObject;
    [SerializeField] GameObject creditsMenuGameObject;
    [SerializeField] GameObject subPauseMenuGameObject;

    private bool isGamePaused = false;

    public void PressedPause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            Time.timeScale = 0.0f;
            subPauseMenuGameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            subPauseMenuGameObject.SetActive(false);
        }
    }

    public void ClickedResumeButton()
    {
        Time.timeScale = 1.0f;
        subPauseMenuGameObject.SetActive(false);
    }

    public void ClickedOptionsButton()
    {
        optionsMenuGameObject.SetActive(true);
    }

    public void ClickedCreditsButton()
    {
        creditsMenuGameObject.SetActive(true);
    }

    public void ClickedMainMenuButton()
    {

    }
}
