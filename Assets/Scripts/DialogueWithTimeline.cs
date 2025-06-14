using UnityEngine;
using Yarn.Unity;
using UnityEngine.Playables;

public class DialogueWithTimeline : MonoBehaviour
{
    public PlayableDirector timelineDirector;
    public DialogueRunner dialogueRunner;

    // 在 Timeline 中通过 Signal 播放对话
    public void StartDialogue()
    {
        // 播放 Timeline
        timelineDirector.Play();
        dialogueRunner.StartDialogue("Start");
    }

    // 用于控制 Timeline 播放，触发 Yarn 对话
    public void OnSignalReceived()
    {
        // 启动对话
        dialogueRunner.StartDialogue("Start");
    }
}
