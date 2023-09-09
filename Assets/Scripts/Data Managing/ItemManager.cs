using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ItemManager : MonoBehaviour
{
    public string title;
    public string description;
    public string link;

    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descText;
    [SerializeField] private float fadeTime;

    private void OnEnable()
    {
        OpenModule();
    }

    // Set the fields of the item according to data
    public void SetFields(string titleValue, string descValue, string linkValue)
    {
        title = titleValue;
        description = descValue;
        link = linkValue;

        titleText.text = titleValue;
        descText.text = descValue;
    }

    // Open the link saved
    public void OpenLink()
    {
        Application.OpenURL(link);
    }

    // The card open animation
    public void OpenModule()
    {
        gameObject.transform.localScale = Vector3.zero;
        gameObject.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
    }

    // The card close animation
    public void CloseModule()
    {
        gameObject.transform.DOScale(Vector3.zero, fadeTime / 3f);
    }
}
