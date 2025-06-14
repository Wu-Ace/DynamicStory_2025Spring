using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [Header("关卡设置")]
    [SerializeField] private string childLevelSceneName = "Level"; // 小孩关卡场景名
    [SerializeField] private string keyLevelSceneName = "Level2"; // 钥匙关卡场景名
    [SerializeField] private float transitionDelay = 2f; // 转场延迟时间

    [Header("转场效果")]
    [SerializeField] private GameObject transitionPanel; // 转场面板
    [SerializeField] private Animator transitionAnimator; // 转场动画控制器

    private bool isTransitioning = false;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // 初始化转场面板
        if (transitionPanel != null)
        {
            transitionPanel.SetActive(false);
        }
    }

    // 检查是否所有小孩都被抓到Home
    public void CheckChildLevelComplete()
    {
        if (isTransitioning) return;

        // 检查是否所有小孩都被吃掉
        bool allChildrenEaten = true;
        Child[] children = FindObjectsOfType<Child>();

        foreach (Child child in children)
        {
            if (child.gameObject.activeSelf)
            {
                allChildrenEaten = false;
                break;
            }
        }

        if (allChildrenEaten)
        {
            Debug.Log("所有小孩都被抓到了，准备切换到钥匙关卡");
            StartTransitionToKeyLevel();
        }
    }

    // 开始转场到钥匙关卡
    private void StartTransitionToKeyLevel()
    {
        isTransitioning = true;
        SceneManager.LoadScene(keyLevelSceneName);

        // 播放转场动画
        if (transitionAnimator != null)
        {
            transitionPanel.SetActive(true);
            transitionAnimator.SetTrigger("FadeOut");
        }

        // 延迟加载新场景
        Invoke(nameof(LoadKeyLevel), transitionDelay);
    }

    // 加载钥匙关卡
    private void LoadKeyLevel()
    {
        SceneManager.LoadScene(keyLevelSceneName);
        isTransitioning = false;
    }

    // 重置关卡
    public void ResetLevel()
    {
        if (isTransitioning) return;

        isTransitioning = true;

        // 播放转场动画
        if (transitionAnimator != null)
        {
            transitionPanel.SetActive(true);
            transitionAnimator.SetTrigger("FadeOut");
        }

        // 延迟重新加载当前场景
        Invoke(nameof(ReloadCurrentLevel), transitionDelay);
    }

    // 重新加载当前场景
    private void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isTransitioning = false;
    }
}