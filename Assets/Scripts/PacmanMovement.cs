using UnityEngine;

public class PacmanMovement : MonoBehaviour
{
    [Header("移动设置")]
    [SerializeField] private float moveSpeed = 5f; // 移动速度
    [SerializeField] private LayerMask obstacleLayer; // 障碍物层

    private Rigidbody2D rb;
    private Vector2 currentDirection = Vector2.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("未找到Rigidbody2D组件！");
        }
    }

    private void Update()
    {
        // 获取输入
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // 重置移动方向
        currentDirection = Vector2.zero;

        // 优先处理水平输入
        if (horizontal != 0)
        {
            Vector2 horizontalDirection = new Vector2(horizontal, 0);
            if (CanMoveInDirection(horizontalDirection))
            {
                currentDirection = horizontalDirection;
            }
        }
        // 如果没有水平输入，则处理垂直输入
        else if (vertical != 0)
        {
            Vector2 verticalDirection = new Vector2(0, vertical);
            if (CanMoveInDirection(verticalDirection))
            {
                currentDirection = verticalDirection;
            }
        }
    }

    private void FixedUpdate()
    {
        // 应用移动
        rb.velocity = currentDirection * moveSpeed;
    }

    // 检查是否可以在指定方向移动
    private bool CanMoveInDirection(Vector2 direction)
    {
        if (direction == Vector2.zero) return false;

        // 发射射线检测前方是否有障碍物
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            direction,
            0.5f, // 射线长度
            obstacleLayer
        );

        return hit.collider == null;
    }

    // 获取当前移动方向
    public Vector2 GetCurrentDirection()
    {
        return currentDirection;
    }
}