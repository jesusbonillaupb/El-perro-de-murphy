using UnityEngine;

public class Muerte : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Movimiento player = collision.GetComponent<Movimiento>();
            if (player != null)
            {
                player.Muerte();
            }
        }
    }
}
