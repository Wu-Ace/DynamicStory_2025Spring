using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Movement))]
public class Child : MonoBehaviour
{
    public Movement movement { get; private set; }
    public Node startingNode;
    public float speed = 2.0f;
    public Transform pacman; // 吃豆人的Transform
    public float detectionRadius = 5f; // 检测吃豆人的范围
    public int points = 100; // 被吃掉时的分数

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        gameObject.SetActive(true);
        this.transform.position = this.startingNode.transform.position;
        this.movement.SetDirection(Vector2.right);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Node node = other.GetComponent<Node>();
        if (node != null)
        {
            // 检查是否在吃豆人附近
            if (pacman != null && Vector2.Distance(transform.position, pacman.position) < detectionRadius)
            {
                // 选择远离吃豆人的方向
                Vector2 direction = Vector2.zero;
                float maxDistance = float.MinValue;

                foreach (Vector2 availableDirection in node.availableDirections)
                {
                    Vector3 newPosition = transform.position + new Vector3(availableDirection.x, availableDirection.y);
                    float distance = (pacman.position - newPosition).sqrMagnitude;

                    if (distance > maxDistance)
                    {
                        direction = availableDirection;
                        maxDistance = distance;
                    }
                }

                movement.SetDirection(direction);
            }
            else
            {
                // 分散模式：随机选择方向，避免掉头
                int index = Random.Range(0, node.availableDirections.Count);

                if (node.availableDirections.Count > 1 && node.availableDirections[index] == -movement.direction)
                {
                    index++;
                    if (index >= node.availableDirections.Count)
                    {
                        index = 0;
                    }
                }

                movement.SetDirection(node.availableDirections[index]);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            // 被吃豆人吃掉
            GameManager.Instance.ChildEaten(this);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Home"))
        {
            Debug.Log("Child碰到了Home层！");
        }
    }
}