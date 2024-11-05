using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 5f;  // Distancia a moverse hacia la izquierda
    public float speed = 2f;         // Velocidad de movimiento de la plataforma
    private bool isMoving = false;   // Controla si la plataforma está en movimiento
    private Vector3 startPosition;   // Posición inicial de la plataforma
    private Vector3 targetPosition;  // Posición objetivo de la plataforma

    private void Start()
    {
        // Guarda la posición inicial de la plataforma
        startPosition = transform.position;

        // Calcula la posición objetivo (hacia la izquierda)
        targetPosition = startPosition - new Vector3(moveDistance, 0, 0);
    }

    private void Update()
    {
        // Si `isMoving` es verdadero, mueve la plataforma hacia la posición objetivo
        if (isMoving)
        {
            // Mueve la plataforma gradualmente hacia la posición objetivo
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Si la plataforma llega a la posición objetivo, detiene el movimiento
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    // Método para iniciar el movimiento de la plataforma
    public void StartMoving()
    {
        isMoving = true;
    }
}
