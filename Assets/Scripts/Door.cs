using UnityEngine;
using UnityEngine.Tilemaps;

public class Door : MonoBehaviour
{
    public Vector3Int tilePosition; // 门在Tilemap中的位置
    private Tilemap tilemap;
    private TilemapCollider2D tilemapCollider;
    private TilemapRenderer tilemapRenderer;

    private void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        tilemapCollider = GetComponent<TilemapCollider2D>();
        tilemapRenderer = GetComponent<TilemapRenderer>();
    }

    public void Unlock()
    {
        // 移除门位置的瓦片
        if (tilemap != null)
        {
            tilemap.SetTile(tilePosition, null);
        }

        // 禁用碰撞器
        if (tilemapCollider != null)
        {
            tilemapCollider.enabled = false;
        }
        if (tilemapRenderer != null)
        {
            tilemapRenderer.enabled = false;
        }
    }

    public void Lock()
    {
        // 重新放置门瓦片
        if (tilemap != null)
        {
            // 注意：这里需要设置回原来的门瓦片
            // 您需要在Inspector中设置门的瓦片
            tilemap.SetTile(tilePosition, doorTile);
        }

        // 启用碰撞器
        if (tilemapCollider != null)
        {
            tilemapCollider.enabled = true;
        }
        if (tilemapRenderer != null)
        {
            tilemapRenderer.enabled = true;
        }
    }

    [SerializeField]
    private TileBase doorTile; // 门的瓦片，在Inspector中设置
}