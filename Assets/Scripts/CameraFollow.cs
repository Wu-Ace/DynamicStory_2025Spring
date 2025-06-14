using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target; // 跟随目标（吃豆人）
    [SerializeField] private float smoothSpeed = 0.125f; // 平滑移动速度
    [SerializeField] private Vector3 offset = new Vector3(0, 0, -10); // 相机偏移量

    private void LateUpdate()
    {
        if (target == null) return;

        // 计算目标位置
        Vector3 desiredPosition = target.position + offset;
        
        // 平滑移动
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        
        // 更新相机位置
        transform.position = smoothedPosition;
    }

    // 设置跟随目标
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
} 