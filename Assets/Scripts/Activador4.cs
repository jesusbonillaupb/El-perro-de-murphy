using UnityEngine;

public class Activador4 : MonoBehaviour
{
    public SierraVertical1 sierra;
    public float moveDistance;
    public float moveDistancex;
    public bool mata;
    public float speed; // Referencia a la plataforma que se moverá

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisiona es el jugador
        if (collision.CompareTag("Player"))
        {
            // Llama al método para mover la plataforma
            sierra.StartMoving(moveDistance, moveDistancex, speed, mata);
        }
    }
}
