using UnityEngine;
using Yarn.Unity;

public class FadeDialogueController : MonoBehaviour
{
    public ScreenFader screenFader;
    public DialogueRunner dialogueRunner;
    public string dialogueNodeName = "Start"; // 要播放的对话节点名称

    private bool hasPlayedDialogue = false; // 添加标志来追踪对话是否已播放

    private void Start()
    {
        // 订阅淡出完成事件
        if (screenFader != null)
        {
            screenFader.OnFadeInComplete += OnFadeInComplete;
        }
    }

    private void OnDestroy()
    {
        // 取消订阅事件
        if (screenFader != null)
        {
            screenFader.OnFadeInComplete -= OnFadeInComplete;
        }
    }

    private void OnFadeInComplete()
    {
        // 检查对话是否已经播放过
        if (!hasPlayedDialogue && dialogueRunner != null)
        {
            dialogueRunner.StartDialogue(dialogueNodeName);
            hasPlayedDialogue = true; // 标记对话已播放
        }
    }
}