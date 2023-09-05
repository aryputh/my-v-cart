using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleScaleAnimation : MonoBehaviour
{
    [SerializeField] private bool scaleOnEnable;
    [Range(0, 1)]
    [SerializeField] private int direction;
    [SerializeField] private float fadeTime;

    private void OnEnable()
    {
        if (scaleOnEnable)
        {
            if (direction == 1)
            {
                OpenModule();
            }
            else
            {
                CloseModule();
            }
        }
    }

    // Plays the open aniamtion
    public void OpenModule()
    {
        gameObject.transform.DOScale(new Vector3(2000f, 2000f, 2000f), fadeTime);
    }

    // Plays the close aniamtion
    public void CloseModule()
    {
        gameObject.transform.DOScale(Vector3.zero, fadeTime);
    }
}
