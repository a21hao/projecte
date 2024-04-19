using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableSetScrollRectAtTop : MonoBehaviour
{
    RectTransform contentTransform;
    private void OnEnable()
    {
        if (contentTransform == null)
        {
            contentTransform = (RectTransform)GetComponentInChildren<UnityEngine.UI.ContentSizeFitter>().transform;
        }
        SetScrollRectAtTopPosition(contentTransform);
    }

    void SetScrollRectAtTopPosition(RectTransform rect)
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 0);
    }



}
