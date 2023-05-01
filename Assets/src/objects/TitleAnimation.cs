using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    public float speed = 1f;
    public float maxScale = 2f;
    public float minScale = 1f;
    public float maxRotation = 30f;
    public float minRotation = -30f;

    private bool isGrowing = true;
    private float currentScale = 1f;
    private float currentRotation = 0f;
    private bool isRotatingRight = true;

    private void Update()
    {
        // animação de aumento e diminuição do objeto
        if (isGrowing)
        {
            currentScale += Time.deltaTime * speed;
            if (currentScale >= maxScale)
            {
                currentScale = maxScale;
                isGrowing = false;
            }
        }
        else
        {
            currentScale -= Time.deltaTime * speed;
            if (currentScale <= minScale)
            {
                currentScale = minScale;
                isGrowing = true;
            }
        }

        // animação de rotação do objeto
        float rotationSpeed = speed * 100f;
        if (isRotatingRight)
        {
            currentRotation += Time.deltaTime * rotationSpeed;
            if (currentRotation > maxRotation)
            {
                currentRotation = maxRotation;
                isRotatingRight = false;
            }
        }
        else
        {
            currentRotation -= Time.deltaTime * rotationSpeed;
            if (currentRotation < minRotation)
            {
                currentRotation = minRotation;
                isRotatingRight = true;
            }
        }

        transform.localScale = new Vector3(currentScale, currentScale, 1f);
        transform.rotation = Quaternion.Euler(0f, 0f, currentRotation);
    }
}
