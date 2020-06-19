using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashTransition : MonoBehaviour
{
    public float fadeRate = 1.0f;
    private Image image;
    public float speed = 1f;

    void Start()
    {
        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("Error: No image component on " + name);
        }
        
    }

    public IEnumerator FadeIn()
    {
        GameEvents.Instance.SplashBegin();
        LeanTween.value(gameObject, 0, 1, speed).setOnUpdate((float val) =>
        {
            Color c = image.color;
            c.a = val;
            image.color = c;
        }).setOnComplete(() =>
        {
            GameEvents.Instance.SplashEnd();
        });
        yield return new WaitForSeconds(speed);
    }

    public IEnumerator FadeOut()
    {
        LeanTween.value(gameObject, 1, 0, speed).setOnUpdate((float val) =>
        {
            Color c = image.color;
            c.a = val;
            image.color = c;
        });
        yield return new WaitForSeconds(speed);
    }
}
