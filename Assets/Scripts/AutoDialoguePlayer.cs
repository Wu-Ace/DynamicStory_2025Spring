using UnityEngine;
using Yarn.Unity;
using System.Collections;

public class AutoDialoguePlayer : MonoBehaviour
{
    public TMPro.TextMeshProUGUI patientAText;
    public TMPro.TextMeshProUGUI patientBText;
    public TMPro.TextMeshProUGUI patientCText;

    [YarnCommand("lineWithDuration")]
    public IEnumerator LineWithDuration(string speaker, string line, float duration)
    {
        // 清空所有
        patientAText.text = "";
        patientBText.text = "";
        patientCText.text = "";

        // 显示指定角色的文本
        switch (speaker)
        {
            case "A":
                patientAText.text = line;
                break;
            case "B":
                patientBText.text = line;
                break;
            case "C":
                patientCText.text = line;
                break;
        }

        // 停顿
        yield return new WaitForSeconds(duration);

        // 清空该角色的文本
        switch (speaker)
        {
            case "A":
                patientAText.text = "";
                break;
            case "B":
                patientBText.text = "";
                break;
            case "C":
                patientCText.text = "";
                break;
        }
    }
}
