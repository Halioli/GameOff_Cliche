using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] GameObject previousMenuGameObject;

    public void ClickedBackButton()
    {
        previousMenuGameObject.SetActive(true);

        gameObject.SetActive(false);
    }
}
