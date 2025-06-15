using UnityEngine;
using Yarn.Unity;

public class DialogueEndFade : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public ScreenFader screenFader;

    void Start()
    {
        dialogueRunner.onDialogueComplete.AddListener(OnDialogueFinished);
        screenFader.StartBlack(); // 一开始黑屏
    }

    void OnDialogueFinished()
    {
        StartCoroutine(screenFader.FadeIn());
    }
}
