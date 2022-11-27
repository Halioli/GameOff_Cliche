using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Configuration;

public class HUD : MonoBehaviour
{
    private const float FADE_TIME = 1.5f;
    private const float SHAKE_AMOUNT = 2.0f;

    // Health
    [SerializeField] int healthShakeThreshold = 10;
    [SerializeField] HealthSystem playerHealthSystem;
    [SerializeField] GameObject healthBarGameObject;
    [SerializeField] CanvasGroup healthCanvasGroup;
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI healthValueText;
    private bool playerIsDamaged = false;
    private bool healthIsTrembeling = false;

    // Fade
    [SerializeField] CanvasGroup fadeCanvasGroup;

    private void Start()
    {
        // Health
        healthSlider.maxValue = playerHealthSystem.GetMaxHealth();
        healthSlider.minValue = playerHealthSystem.GetMinHealth();
        healthSlider.value = playerHealthSystem.GetCurrentHealth();
        healthValueText.text = playerHealthSystem.GetCurrentHealth().ToString();
    }

    private void Update()
    {
        // Health
        SetHealthValue(playerHealthSystem.GetCurrentHealth());

        // Check if element needs to appear/disappear
        ManageShowingHealth();

        // Check if it need to tremble
        if (playerIsDamaged && playerHealthSystem.GetCurrentHealth() <= healthShakeThreshold && !healthIsTrembeling)
        {
            healthIsTrembeling = true;
            StartCoroutine(ShakeHealthGameObject());
        }
    }

    // Health
    public void SetHealthValue(int value)
    {
        healthSlider.value = value;
        healthValueText.text = value.ToString();
    }

    private void ManageShowingHealth()
    {
        if ((playerHealthSystem.GetCurrentHealth() < playerHealthSystem.GetMaxHealth()) && !playerIsDamaged)
        {
            StopCoroutine(CanvasFadeOut(healthCanvasGroup)); // stop fade out
            StartCoroutine(CanvasFadeIn(healthCanvasGroup)); // start fade in
            playerIsDamaged = true;
        }
        else if (!(playerHealthSystem.GetCurrentHealth() < playerHealthSystem.GetMaxHealth()) && playerIsDamaged)
        {
            StopCoroutine(ShakeHealthGameObject()); // stop shake
            StopCoroutine(CanvasFadeIn(healthCanvasGroup)); // stop fade in
            StartCoroutine(CanvasFadeOut(healthCanvasGroup)); // start fade out
            playerIsDamaged = false;
            healthIsTrembeling = false;
        }
    }

    // Fade
    public void FadeToBalack()
    {
        StopCoroutine(CanvasFadeOut(fadeCanvasGroup));
        StartCoroutine(CanvasFadeIn(fadeCanvasGroup));
    }

    public void FadeToGame()
    {
        StopCoroutine(CanvasFadeIn(fadeCanvasGroup));
        StartCoroutine(CanvasFadeOut(fadeCanvasGroup));
    }

    IEnumerator CanvasFadeOut(CanvasGroup canvasGroup)
    {
        Vector2 startVector = new Vector2(1f, 1f);
        Vector2 endVector = new Vector2(0f, 0f);

        for (float t = 0f; t < FADE_TIME; t += Time.deltaTime)
        {
            float normalizedTime = t / FADE_TIME;

            canvasGroup.alpha = Vector2.Lerp(startVector, endVector, normalizedTime).x;
            yield return null;
        }
        canvasGroup.alpha = endVector.x;
    }

    IEnumerator CanvasFadeIn(CanvasGroup canvasGroup)
    {
        Vector2 startVector = new Vector2(0f, 0f);
        Vector2 endVector = new Vector2(1f, 1f);

        for (float t = 0f; t < FADE_TIME; t += Time.deltaTime)
        {
            float normalizedTime = t / FADE_TIME;

            canvasGroup.alpha = Vector2.Lerp(startVector, endVector, normalizedTime).x;
            yield return null;
        }
        canvasGroup.alpha = endVector.x;
    }

    IEnumerator ShakeHealthGameObject()
    {
        Vector2 startingPos = healthBarGameObject.transform.localPosition;
        Vector2 currentPos = startingPos;

        while (healthIsTrembeling)
        {
            currentPos.x += Random.Range(-SHAKE_AMOUNT, SHAKE_AMOUNT);
            currentPos.y += Random.Range(-SHAKE_AMOUNT, SHAKE_AMOUNT);
            healthBarGameObject.transform.localPosition = currentPos;

            yield return null;
            healthBarGameObject.transform.localPosition = startingPos;
            currentPos = startingPos;
        }

        yield return new WaitWhile(() => healthIsTrembeling);
        healthBarGameObject.transform.localPosition = startingPos;
    }
}
