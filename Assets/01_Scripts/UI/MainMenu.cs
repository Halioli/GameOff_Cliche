using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Image loadingBarImage;
    [SerializeField] CanvasGroup loadingBarGroup;
    [SerializeField] GameObject optionsMenuGameObject;
    [SerializeField] GameObject creditsMenuGameObject;

    public void PlayButtonClicked(int sceneIndex)
    {
        loadingBarGroup.alpha = 1f;
        StartCoroutine(AsyncLoading(sceneIndex));
    }

    public void OptionsButtonClick()
    {
        optionsMenuGameObject.SetActive(true);
    }

    public void CreditsButtonClick()
    {
        creditsMenuGameObject.SetActive(true);
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

    IEnumerator AsyncLoading(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);

        float progress;
        while (!operation.isDone)
        {
            progress = Mathf.Clamp01(operation.progress / .9f);

            loadingBarImage.fillAmount = progress;
            yield return null;
        }
    }
}
