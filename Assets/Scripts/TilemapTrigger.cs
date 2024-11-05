using UnityEngine;

public class TilemapTrigger : MonoBehaviour
{
    private Renderer tilemapRenderer;

    void Start()
    {
        tilemapRenderer = GetComponent<Renderer>();
        tilemapRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            tilemapRenderer.enabled = true;

            Movimiento player = collision.GetComponent<Movimiento>();
            if (player != null)
            {
                player.Muerte();
            }
        }
    }
}
