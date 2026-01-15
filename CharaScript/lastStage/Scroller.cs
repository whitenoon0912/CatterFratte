using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    public ScrollRect scrollRect;    // ScrollRectコンポーネントをアタッチ
    public float scrollSpeed = 0.001f; // スクロール速度（0〜1の範囲が多い）

    void Update()
    {
        if (scrollRect != null)
        {
            float newPosition = scrollRect.verticalNormalizedPosition - scrollSpeed * Time.deltaTime;
            scrollRect.verticalNormalizedPosition = newPosition;
        }
    }
}

