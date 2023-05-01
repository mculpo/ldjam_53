using UnityEngine;
using UnityEngine.UI;

public class RotateStarAnimation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // rotaciona a imagem em torno do eixo Y
        rectTransform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}

