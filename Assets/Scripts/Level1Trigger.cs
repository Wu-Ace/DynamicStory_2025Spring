using UnityEngine;

public class Level1Trigger : MonoBehaviour
{
    [SerializeField] private string level1SceneName = "Level 1"; // Level 1场景名称
    [SerializeField] private LayerMask pacmanLayer; // 吃豆人所在的层

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查是否是吃豆人层
        if (((1 << other.gameObject.layer) & pacmanLayer) != 0)
        {
            // 使用SceneTransitionManager切换到Level 1
            SceneTransitionManager.Instance.LoadNextScene();
        }
    }
}