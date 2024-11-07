using UnityEngine;

public class Activador5 : MonoBehaviour
{
    public TilemapTrigger2 sierra;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.CompareTag("Player"))
        {
            // Llama al método para mover la plataforma
            sierra.aparecer();
        }
    }
}
