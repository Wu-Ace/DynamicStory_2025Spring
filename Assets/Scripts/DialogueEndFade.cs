using UnityEngine;
using Yarn.Unity;

public class DialogueEndFade : MonoBehaviour
{
    public DialogueRunner dialogueRunner;
    public ScreenFader screenFader;

    public RoomMovement roomMovement;

    void Start()
    {
        dialogueRunner.onDialogueComplete.AddListener(OnDialogueFinished);
        screenFader.StartBlack(); // 一开始黑屏
        roomMovement.enabled = false;
    }

    void OnDialogueFinished()
    {
        StartCoroutine(screenFader.FadeIn());
        roomMovement.enabled = true;
    }
}
