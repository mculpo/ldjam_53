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

        // Calcular a dire��o da seta
        // Calcular a dire��o da c�mera at� o alvo subtraindo a posi��o da c�mera pela posi��o do alvo
        Vector3 direction = target.position - cam.transform.position;

        // Obter o valor m�nimo entre os valores absolutos dos limites esquerdo, direito, superior e inferior para usar como limite de dist�ncia da seta em rela��o � c�mera
        distance = Mathf.Min(Mathf.Abs(leftLimit), Mathf.Abs(rightLimit), Mathf.Abs(topLimit), Mathf.Abs(bottomLimit));

        // Calcular o multiplicador de dist�ncia com base na dire��o da seta em rela��o � c�mera,
        // usando o tamanho ortogr�fico e a propor��o de aspecto da c�mera para determinar o fator de dist�ncia para as dire��es x e y
        float multiplicadorDistancia = Mathf.Max(Mathf.Abs(direction.x) / (cam.orthographicSize * cam.aspect), Mathf.Abs(direction.y) / cam.orthographicSize);

        // Limitar o multiplicador de dist�ncia a um valor entre 0 e 1
        multiplicadorDistancia = Mathf.Clamp01(multiplicadorDistancia);

        // Multiplicar o limite de dist�ncia pelo multiplicador de dist�ncia para obter a dist�ncia final da seta em rela��o � c�mera
        distance *= multiplicadorDistancia;

        // Normalizar o vetor de dire��o e multiplic�-lo pela soma do tamanho ortogr�fico da c�mera e da dist�ncia para posicionar a seta
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
