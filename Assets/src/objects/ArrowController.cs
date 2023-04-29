using UnityEngine;
public class ArrowController : MonoBehaviour
{
    public Transform target;
    public float leftLimit = -6;
    public float rightLimit = 6;
    public float topLimit = 4.8f;
    public float bottomLimit = -4.8f;

    private Camera cam;
    private SpriteRenderer spriteRenderer;
    private float distance;

    private void Start()
    {
        cam = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector3 targetViewport = cam.WorldToViewportPoint(target.position);

        if (targetViewport.x < 0f || targetViewport.x > 1f || targetViewport.y < 0f || targetViewport.y > 1f)
        {
            targetViewport.x = Mathf.Clamp01(targetViewport.x);
            targetViewport.y = Mathf.Clamp01(targetViewport.y);
        }

        // Calcular a direção da seta
        // Calcular a direção da câmera até o alvo subtraindo a posição da câmera pela posição do alvo
        Vector3 direction = target.position - cam.transform.position;

        // Obter o valor mínimo entre os valores absolutos dos limites esquerdo, direito, superior e inferior para usar como limite de distância da seta em relação à câmera
        distance = Mathf.Min(Mathf.Abs(leftLimit), Mathf.Abs(rightLimit), Mathf.Abs(topLimit), Mathf.Abs(bottomLimit));

        // Calcular o multiplicador de distância com base na direção da seta em relação à câmera,
        // usando o tamanho ortográfico e a proporção de aspecto da câmera para determinar o fator de distância para as direções x e y
        float multiplicadorDistancia = Mathf.Max(Mathf.Abs(direction.x) / (cam.orthographicSize * cam.aspect), Mathf.Abs(direction.y) / cam.orthographicSize);

        // Limitar o multiplicador de distância a um valor entre 0 e 1
        multiplicadorDistancia = Mathf.Clamp01(multiplicadorDistancia);

        // Multiplicar o limite de distância pelo multiplicador de distância para obter a distância final da seta em relação à câmera
        distance *= multiplicadorDistancia;

        // Normalizar o vetor de direção e multiplicá-lo pela soma do tamanho ortográfico da câmera e da distância para posicionar a seta
        direction = direction.normalized * (cam.orthographicSize + distance);

        // Position the arrow
        Vector3 newPosition = cam.transform.position + direction;
        newPosition.x = Mathf.Clamp(newPosition.x, cam.transform.position.x + leftLimit, cam.transform.position.x + rightLimit);
        newPosition.y = Mathf.Clamp(newPosition.y, cam.transform.position.y + bottomLimit, cam.transform.position.y + topLimit);
        transform.position = newPosition;

        // Rotate the arrow
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
    }
}
