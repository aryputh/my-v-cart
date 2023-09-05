using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AddItemContainerAnimation : MonoBehaviour
{
    [SerializeField] private float fadeTime;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private RectTransform rectTransform;

    // Animate the module opening
    public void OpenModule()
    {
        canvasGroup.alpha = 0;
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
    }

    // Animate the module closing
    public void CloseModule()
    {
        canvasGroup.alpha = 1;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(1, fadeTime);
    }
}
