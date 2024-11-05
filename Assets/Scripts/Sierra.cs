using UnityEngine;
using UnityEngine.Tilemaps;

public class Sierra : MonoBehaviour
{
    private float moveDistance;     // Distancia a moverse hacia la izquierda
    private float speed;  // Velocidad de movimiento de la plataforma
    private bool muerte;
    private bool isMoving = false;  // Controla si la plataforma está en movimiento
    private Vector3 startPosition;  // Posición inicial de la plataforma
    private Vector3 targetPosition; // Posición objetivo de la plataforma

    private void Start()
    {
        // Guarda la posición inicial de la plataforma
        startPosition = transform.position;
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
                muerte = true;
            }
        }
    }

    // Método para iniciar el movimiento de la plataforma con parámetros
    public void StartMoving(float distancia, float velocidad, bool mata)
    {
        moveDistance = distancia; // Asigna la distancia
        speed = velocidad;        // Asigna la velocidad
        muerte = mata;

        // Calcula la posición objetivo (hacia la izquierda)
        targetPosition = startPosition - new Vector3(moveDistance, 0, 0);

        isMoving = true; // Inicia el movimiento
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            if (muerte)
            {
                Movimiento player = collision.GetComponent<Movimiento>();
                if (player != null)
                {
                    player.Muerte();
                }
            }
        }
    }
}
