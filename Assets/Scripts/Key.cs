using UnityEngine;
using UnityEngine.Tilemaps;

public class Key : MonoBehaviour
{
    public int points = 200; // 吃到钥匙的分数
    [SerializeField] private GameObject correspondingDoor; // 对应的门

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Key被触发，触发物体层：{other.gameObject.layer}，名称：{other.gameObject.name}");

        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Debug.Log("检测到Pacman层，准备处理碰撞");

            // 增加分数
            GameManager.Instance.KeyEaten(this);

            // 禁用钥匙和对应的门
            if (correspondingDoor != null)
            {
                correspondingDoor.SetActive(false);
            }
            gameObject.SetActive(false);
        }
    }
}