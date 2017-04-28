using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAnimation : MonoBehaviour
{
    // 애니메이션 클립 추가는 해당 변수의 추가로 제작
    public Sprite[] animation;
    public Sprite[] animation1;
    public Sprite[] animation2;
    public Sprite[] animation3;
    public Sprite[] animation4;

    private Sprite[] targetAnimation;
    public float delayTime = 0.1f;
    private bool repeat = false;
    private SpriteRenderer targetRenderer;
    private System.Action callback = null;

    public void StartAnimation(SpriteRenderer renderer, int animationNumber, float delayTime,System.Action callback = null, bool repeat = false)
    {
        StopCoroutine(Co_Animation());

        this.repeat = repeat;
        this.delayTime = delayTime;
        this.callback = callback;
        targetRenderer = renderer;

        switch (animationNumber)
        {
            case 0: targetAnimation = animation;  break;
            case 1: targetAnimation = animation1; break;
            case 2: targetAnimation = animation2; break;
            case 3: targetAnimation = animation3; break;
            case 4: targetAnimation = animation4; break;
            default:
                break;
        }

        StartCoroutine(Co_Animation());
    }

    IEnumerator Co_Animation()
    {
        do
        {
            for (int i = 0; i < targetAnimation.Length; i++)
            {
                targetRenderer.sprite = targetAnimation[i];
                yield return new WaitForSeconds(delayTime);
            }
        } while (repeat);
        if (callback != null)
        {
            callback();
        }
    }
}
