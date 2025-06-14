using UnityEngine;
using UnityEngine.Tilemaps;

public class Key : MonoBehaviour
{
    public int points = 200; // 吃到钥匙的分数
    public Vector3Int targetDoorPosition; // 目标门在Tilemap中的位置

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            // 查找并解锁对应位置的门
            Door[] doors = FindObjectsOfType<Door>();
            foreach (Door door in doors)
            {
                if (door.tilePosition == targetDoorPosition)
                {
                    door.Unlock();
                    break;
                }
            }

            // 增加分数
            GameManager.Instance.KeyEaten(this);

            // 禁用钥匙
            gameObject.SetActive(false);
        }
    }
}