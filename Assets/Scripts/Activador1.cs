using UnityEngine;

public class Activador1 : MonoBehaviour
{
    public MovingPlatform platform;  // Referencia a la plataforma que se moverá

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.CompareTag("Player"))
        {
            // Llama al método para mover la plataforma
            platform.StartMoving();
        }
    }
}
