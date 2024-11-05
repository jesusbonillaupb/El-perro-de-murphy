using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 5f;  // Distancia a moverse hacia la izquierda
    public float speed = 2f;         // Velocidad de movimiento de la plataforma
    private bool isMoving = false;   // Controla si la plataforma est� en movimiento
    private Vector3 startPosition;   // Posici�n inicial de la plataforma
    private Vector3 targetPosition;  // Posici�n objetivo de la plataforma

    private void Start()
    {
        // Guarda la posici�n inicial de la plataforma
        startPosition = transform.position;

        // Calcula la posici�n objetivo (hacia la izquierda)
        targetPosition = startPosition - new Vector3(moveDistance, 0, 0);
    }

    private void Update()
    {
        // Si `isMoving` es verdadero, mueve la plataforma hacia la posici�n objetivo
        if (isMoving)
        {
            // Mueve la plataforma gradualmente hacia la posici�n objetivo
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Si la plataforma llega a la posici�n objetivo, detiene el movimiento
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    // M�todo para iniciar el movimiento de la plataforma
    public void StartMoving()
    {
        isMoving = true;
    }
}
