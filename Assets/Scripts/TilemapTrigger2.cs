using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapTrigger2 : MonoBehaviour
{
    private Renderer tilemapRenderer;
    private TilemapCollider2D tilemapCollider;

    public void aparecer()
    {
        tilemapRenderer = GetComponent<Renderer>();
        tilemapCollider = GetComponent<TilemapCollider2D>();
        tilemapRenderer.enabled = true;
        tilemapCollider.enabled = true;
    }
}
