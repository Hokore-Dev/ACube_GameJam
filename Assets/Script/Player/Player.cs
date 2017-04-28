using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Shake shake;

    [SerializeField]
    GameEngine gameEngine;

    [SerializeField]
    FiberBar fiberBar;

    public enum EState
    {
        Ready,
        Start,
        Fly,
        Game,
        Finish
    }

    private EState state = EState.Ready;
    private SpriteRenderer characterRenderer;
    private ImageAnimation animation;

    private void Awake()
    {
        animation = GetComponent<ImageAnimation>();
        characterRenderer = GetComponent<SpriteRenderer>();

        animation.StartAnimation(characterRenderer, (int)EState.Ready, 0.2f, null, true);
    }

    private void SetGameSetting()
    {
        characterRenderer.transform.localPosition = new Vector3(0, 0f, 0);
        fiberBar.gameObject.SetActive(true);
        animation.StartAnimation(characterRenderer, (int)EState.Game, 0.2f, null, true);
        gameEngine.SetCubicRandomPosition();
        LeanTween.moveY(this.gameObject, -0.5f, 3).setEaseOutSine();
    }

    public void SetState(EState state)
    {
        switch (state)
        {
            case EState.Start:
                LeanTween.moveY(this.gameObject, 1.5f, 0.27f);
                animation.StartAnimation(characterRenderer, (int)EState.Start, 0.1f, ()=>
                {
                    SetGameSetting();
                }, false);
                break;
            case EState.Finish:
                animation.StartAnimation(characterRenderer,0, 0.1f,null,true);
                LeanTween.moveLocalY(this.gameObject, -3, 0.5f).setEaseInBack().setOnComplete(() => {
                    shake.MakeShake(5);
                });
                break;
            case EState.Fly:
                animation.StartAnimation(characterRenderer, (int)EState.Fly, 0.2f, null, true);
                if (!fiberBar.isFiberTime)
                {
                    fiberBar.gameObject.SetActive(false);
                    LeanTween.moveLocalY(characterRenderer.gameObject, 8.0f, 1.0f)
                    .setDelay(0.1f)
                    .setEaseInBack()
                    .setOnComplete(() => {
                        SetGameSetting();
                    });
                }
                break;
            default:
                break;
        }
    }
}
