using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiberBar : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer gauageBar;

    private const float FIBER_TIME = 2.0f;
    private int fiberCount = 4;
    private bool isFiberTime = false;
    private System.Action fiberTimeOutCallback = null;

    private void Start()
    {
        UpdateFiberBar(null);
    }

    public void SetFiberCallback(System.Action callback)
    {
        fiberTimeOutCallback = callback;
    }

    public bool AddFiberCount()
    {
        if (isFiberTime)
            return false;

        fiberCount++;
        if (fiberCount == 5)
        {
            isFiberTime = true;
            UpdateFiberBar(()=> {
                LeanTween.scaleX(gauageBar.gameObject, 0, FIBER_TIME).setOnComplete(() => {
                    isFiberTime = false;
                    if (fiberTimeOutCallback != null)
                        fiberTimeOutCallback();
                });
            });
            fiberCount = 0;
            return true;
        }
        else
        {
            UpdateFiberBar(null);
        }
        return false;
    }

    private void UpdateFiberBar(System.Action callback)
    {
        LeanTween.scaleX(gauageBar.gameObject, fiberCount * 0.4f, 0.1f).setOnComplete(() => {
            if (callback != null)
                callback();
        });
    }
}
