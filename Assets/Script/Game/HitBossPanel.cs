using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBossPanel : MonoBehaviour {

    [SerializeField]
    Image userBar;

    [SerializeField]
    Text text;

    public System.Action callback = null;
    private bool check = false;
    public float value = 500;

    public enum EState
    {
        Bad,
        Normal,
        Good,
        Perfect
    }

    public void Disappear()
    {
        LeanTween.alphaCanvas(this.GetComponent<CanvasGroup>(), 0, 0.3f).setOnComplete(callback);
    }
    
    public void StartUserBar()
    {
        LeanTween.moveLocalX(userBar.gameObject, 500, 1.0f).setOnComplete(() => {
            if (!check)
            {
                ShowLevel(EState.Bad);
            }
        }); 
    }

    public EState CheckTime()
    {
        // NOTE @minjun 게이지바를 누르면 멈추게 설정
        LeanTween.cancel(userBar.gameObject);

        value = Mathf.Abs(userBar.transform.localPosition.x - 0);
        if (value < 50)
            return EState.Perfect;
        else if (value < 70)
            return EState.Good;
        else if (value < 100)
            return EState.Normal;
        return EState.Bad;
    }

    public void ShowLevel(EState state)
    {
        check = true;
        switch (state)
        {
            case EState.Bad:
                text.text = "효과는 미비했다!";
                break;
            case EState.Normal:
                text.text = "이 정도 쯤이야~";
                break;
            case EState.Good:
                text.text = "크리티컬 히트!";
                break;
            case EState.Perfect:
                text.text = "일격 필살!!!";
                break;
            default:
                break;
        }
        LeanTween.scale(text.gameObject, new Vector3(1, 1, 1), 0.25f);
        LeanTween.alphaCanvas(text.GetComponent<CanvasGroup>(), 1, 0.25f).setOnComplete(Disappear);
    }
}
