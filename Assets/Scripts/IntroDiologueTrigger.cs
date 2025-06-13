using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class IntroDiologueTrigger : MonoBehaviour
{
    public DialogueRunner dialogueRunner; // 拖进来
    public string nodeName = "Intro"; // 对应你的 Yarn 节点

    // 比如这是你的触发条件
    public bool conditionMet = false;

    void Update()
    {
        // 示例条件：按下 E 键且条件成立
        if (Input.GetKeyDown(KeyCode.E) && !dialogueRunner.IsDialogueRunning)
        {
            dialogueRunner.StartDialogue(nodeName);
        }
    }
}
