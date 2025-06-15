using UnityEngine;

public class SpiritFollow : MonoBehaviour
{
    [SerializeField] private Transform pacman; // Pacman的Transform引用
    [SerializeField] private float smoothSpeed = 0.125f; // 平滑移动的速度
    [SerializeField] private Vector3 offset = new Vector3(0, 0, 0); // 相对于Pacman的偏移量
    [SerializeField] private GameObject spiritObject; // 精灵子物体

    private void Start()
    {
        // 如果没有手动指定Pacman，尝试自动查找
        if (pacman == null)
        {
            GameObject pacmanObj = GameObject.FindGameObjectWithTag("Pacman");
            if (pacmanObj != null)
            {
                pacman = pacmanObj.transform;
            }
        }

        // 如果没有手动指定spiritObject，尝试获取第一个子物体
        if (spiritObject == null && transform.childCount > 0)
        {
            spiritObject = transform.GetChild(0).gameObject;
        }

        // 初始时隐藏精灵
        if (spiritObject != null)
        {
            spiritObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        if (pacman == null || spiritObject == null) return;

        // 计算目标位置
        Vector3 desiredPosition = pacman.position + offset;

        // 使用平滑插值移动
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    // 当吃豆人吃掉小孩时调用
    public void ShowSpirit()
    {
        if (spiritObject != null)
        {
            spiritObject.SetActive(true);
        }
    }

    // 当吃豆人回到home时调用
    public void HideSpirit()
    {
        if (spiritObject != null)
        {
            spiritObject.SetActive(false);
        }
    }
}