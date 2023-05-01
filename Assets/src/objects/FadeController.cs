using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : Singleton<FadeController>
{
    public float durationIn = 3; // duração do fade in
    public float durationOut = 1; // duração do fade in
    private Image image; // referência ao componente Image

    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeOutCoroutine());
    }

    public IEnumerator FadeInCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < durationIn)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / durationIn);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }

    public IEnumerator FadeOutCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < durationOut)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / durationOut);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }
}
