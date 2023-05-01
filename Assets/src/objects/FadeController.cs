using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : Singleton<FadeController>
{
    public float duration; // dura��o do fade in
    private Image image; // refer�ncia ao componente Image

    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeOutCoroutine());
    }

    public IEnumerator FadeInCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / duration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
    }

    public IEnumerator FadeOutCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }
}
