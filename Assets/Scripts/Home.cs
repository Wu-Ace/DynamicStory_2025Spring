using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    [SerializeField] private Image homeImage; // 拖入Home区域的Image组件
    private Color originalColor; // 原始颜色
    private int totalChildren = 3; // 总孩子数量，根据实际游戏设置调整

    private void Start()
    {
        if (homeImage != null)
        {
            originalColor = homeImage.color;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Debug.Log("Pacman进入了Home！");
            GameManager.Instance.PacmanEnteredHome();
            UpdateHomeColor();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Debug.Log("Pacman离开了Home！");
            GameManager.Instance.PacmanLeftHome();
        }
    }

    private void UpdateHomeColor()
    {
        if (homeImage != null)
        {
            // 获取当前已收集的孩子数量
            int collectedChildren = GameManager.Instance.GetCollectedChildrenCount();

            // 计算颜色渐变
            float redIntensity = Mathf.Lerp(originalColor.r, 1f, (float)collectedChildren / totalChildren);
            Color newColor = new Color(redIntensity, originalColor.g, originalColor.b, originalColor.a);

            // 应用新颜色
            homeImage.color = newColor;
        }
    }
}
