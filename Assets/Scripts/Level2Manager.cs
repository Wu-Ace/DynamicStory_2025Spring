using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Manager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private string endSceneName = "End"; // 结束场景的名称
    [SerializeField] private float sceneTransitionDelay = 2f; // 场景切换延迟时间

    private bool hasWon = false;

    private void Update()
    {
        // 检查是否已经获胜
        if (!hasWon)
        {
            // 检查是否所有豆子都被吃完
            if (!gameManager.HasRemainingPellets())
            {
                hasWon = true;
                // 延迟切换到结束场景
                Invoke(nameof(LoadEndScene), sceneTransitionDelay);
            }
        }
    }

    private void LoadEndScene()
    {
        // 加载结束场景
        SceneManager.LoadScene(endSceneName);
    }
}