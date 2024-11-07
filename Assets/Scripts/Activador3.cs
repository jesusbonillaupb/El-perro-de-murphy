using UnityEngine;

public class Activador3 : MonoBehaviour
{
    public SierraVertical sierra;
    public float moveDistance;
    public bool mata;
    public float speed; // Referencia a la plataforma que se moverá

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.CompareTag("Player"))
        {
            // Llama al método para mover la plataforma
            sierra.StartMoving(moveDistance, speed, mata);
        }
    }
}
