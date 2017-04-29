using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiberBar : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer gauageBar;

    [SerializeField]
    AudioSource bgm;

    [SerializeField]
    AudioSource mainBGM;

    [SerializeField]
     FeverAniBG bg;

    private const float FIBER_TIME = 3.0f;
    private int fiberCount = 4;
    public bool isFiberTime = false;
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
            mainBGM.Stop();
            bgm.Play();
            LeanTween.value(bgm.gameObject, 0, 1.0f, 0.3f)
       .setEase(LeanTweenType.linear)
       .setOnUpdate((float val) => {
           bgm.volume = val;
       });
            bg.StartAni();
            THHeightManager.Instance.AddHeight(THGameSetting.Instance.autoFeverHeight, FIBER_TIME);
            isFiberTime = true;

            UpdateFiberBar(()=> {

                LeanTween.scaleX(gauageBar.gameObject, 0, FIBER_TIME).setOnComplete(() => {
                    mainBGM.Play();
                    LeanTween.value(bgm.gameObject, 1, 0, 0.3f)
               .setEase(LeanTweenType.linear)
               .setOnUpdate((float val) => {
                   bgm.volume = val;
                   if (val <= 0)
                       bgm.Stop();
               });
                    bg.StopAni();
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
        LeanTween.scaleX(gauageBar.gameObject, fiberCount * 0.2f, 0.1f).setOnComplete(() => {
            if (callback != null)
                callback();
        });
    }
}
