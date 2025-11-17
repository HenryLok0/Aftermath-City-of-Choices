using UnityEngine;
using UnityEngine.UI;
using TMPro; // 加入這行

public class BlackMaskFade : MonoBehaviour
{
    public Image blackMask;
    public TMP_Text titleText;  // 用 TextMeshPro 用這個型別！

    // 1. 顯示黑幕（瞬間全黑）
    public void ShowBlack()
    {
        if (blackMask != null)
        {
            Color c = blackMask.color;
            blackMask.color = new Color(c.r, c.g, c.b, 1);
            blackMask.gameObject.SetActive(true);
        }
        if (titleText != null)
        {
            titleText.gameObject.SetActive(true);
        }
    }

    // 2. 開始淡出：標題消失＆黑幕淡出
    public void BeginFade()
    {
        if (titleText != null)
            titleText.gameObject.SetActive(false);
        StartCoroutine(FadeOut());
    }

    // 3. 慢慢淡出黑幕
    System.Collections.IEnumerator FadeOut()
    {
        float t = 0;
        Color c = blackMask.color;
        while (t < 1)
        {
            t += Time.deltaTime / 1.5f;
            blackMask.color = new Color(c.r, c.g, c.b, Mathf.Lerp(1, 0, t));
            yield return null;
        }
        blackMask.color = new Color(c.r, c.g, c.b, 0);
        blackMask.gameObject.SetActive(false);
    }
}
