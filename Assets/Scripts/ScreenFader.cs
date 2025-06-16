using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ScreenFader : MonoBehaviour
{
    public CanvasGroup blackOverlay;
    public float fadeDuration = 1f;

    // 添加淡出完成事件
    public event Action OnFadeInComplete;

    public void StartBlack()
    {
        blackOverlay.alpha = 1f;
    }

    public IEnumerator FadeIn() // 淡出黑屏
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            blackOverlay.alpha = 1f - (t / fadeDuration);
            yield return null;
        }
        blackOverlay.alpha = 0f;
        blackOverlay.gameObject.SetActive(false);

        // 触发淡出完成事件
        OnFadeInComplete?.Invoke();
    }
}
