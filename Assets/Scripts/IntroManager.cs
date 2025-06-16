using UnityEngine;
using UnityEngine.Playables;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector cameraTimeline;
    [SerializeField] private GameManager gameManager;

    private bool hasPlayedIntro = false;
    private float gameTimer = 0f;
    private const float TIMELINE_TRIGGER_TIME = 60f; // 1分钟 = 60秒

    public bool DeveloperMode_Win = false;

    private void Start()
    {
        // Ensure the timeline doesn't play at the start
        if (cameraTimeline != null)
        {
            cameraTimeline.Stop();
        }
    }

    private void Update()
    {
        if (!hasPlayedIntro)
        {
            // 更新游戏计时器
            gameTimer += Time.deltaTime;

            // 检查是否达到1分钟
            if (gameTimer >= TIMELINE_TRIGGER_TIME)
            {
                PlayCameraTimeline();
            }
        }

        // 保留开发者模式选项
        if (DeveloperMode_Win && !hasPlayedIntro)
        {
            PlayCameraTimeline();
        }
    }

    private void PlayCameraTimeline()
    {
        if (cameraTimeline != null)
        {
            cameraTimeline.Play();
            hasPlayedIntro = true;
        }
    }
}