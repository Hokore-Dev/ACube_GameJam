using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageAnimation : MonoBehaviour
{
    // 애니메이션 클립 추가는 해당 SerializeField의 추가로 제작
    [SerializeField]
    Sprite[] animation;

    [SerializeField]
    Sprite[] animation1;

    private Sprite[] targetAnimation;
    public float delayTime = 0.1f;
    private bool repeat = false;
    private SpriteRenderer targetRenderer;
    private System.Action callback = null;

    public void StartAnimation(SpriteRenderer renderer, int animationNumber, float delayTime,System.Action callback = null, bool repeat = false)
    {
        this.repeat = repeat;
        this.delayTime = delayTime;
        this.callback = callback;
        targetRenderer = renderer;

        switch (animationNumber)
        {
            case 0: targetAnimation = animation;  break;
            case 1: targetAnimation = animation1; break;
            default:
                break;
        }

        StartCoroutine(Co_Animation());
    }

    IEnumerator Co_Animation()
    {
        while(repeat)
        {
            for (int i = 0; i < animation.Length; i++)
            {
                targetRenderer.sprite = animation[i];
                yield return new WaitForSeconds(delayTime);
            }
        }
        if (callback != null)
        {
            callback();
        }
    }
}
