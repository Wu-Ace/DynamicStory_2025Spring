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

    public DialogueRunner runner;

void Start() {
    runner.StartDialogue("Intro");
}

}
