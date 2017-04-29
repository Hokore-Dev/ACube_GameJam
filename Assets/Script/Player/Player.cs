using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    Shake shake;

    [SerializeField]
    GameEngine gameEngine;

    [SerializeField]
    FiberBar fiberBar;

    [SerializeField]
    CanvasGroup toMain;

    [SerializeField]
    CanvasGroup fadebox;

    [SerializeField]
    Text score;

    [SerializeField]
    Image loading;

    [SerializeField]
    ImageAnimation upAni;

    [SerializeField]
    AudioSource jumpBGM;

    public enum EState
    {
        Ready,
        Start,
        Fly,
        Game,
        Finish
    }

    private EState state = EState.Ready;
    public SpriteRenderer characterRenderer;
    public ImageAnimation animation;
    private int meter = 0;
    int level = 1;

    private void Awake()
    {
        animation = GetComponent<ImageAnimation>();
        characterRenderer = GetComponent<SpriteRenderer>();

        animation.StartAnimation(characterRenderer, (int)EState.Ready, 0.2f, null, true);        
    }

    private void SetGameSetting()
    {
        // 게임 베이스 타임 시작        
        THHPManager.Instance.HPDamageStart();
        THSkyBackground.Instance.StartBackground();

        characterRenderer.transform.localPosition = new Vector3(0, 0.1f, 0);
        fiberBar.gameObject.SetActive(true);
        animation.StartAnimation(characterRenderer, (int)EState.Game, 0.2f, null, true);
        gameEngine.SetCubicRandomPosition();
        LeanTween.moveY(this.gameObject, -0.4f, 3).setEaseOutSine();
    }

    public void SetState(EState state)
    {
        switch (state)
        {
            case EState.Start:
                jumpBGM.Play();
                LeanTween.moveY(this.gameObject, 1.0f, 0.27f).setDelay(0.3f);
                animation.StartAnimation(characterRenderer, (int)EState.Start, 0.1f, ()=>
                {
                    fadebox.gameObject.SetActive(true);
                    LeanTween.alphaCanvas(fadebox, 1, 0.2f).setOnComplete(() => {
                        loading.gameObject.SetActive(true);
                        LeanTween.alphaCanvas(fadebox, 0, 0.2f).setOnComplete(() => {
                            fadebox.gameObject.SetActive(false);
                            loading.gameObject.SetActive(true);
                            LeanTween.alphaCanvas(loading.GetComponent<CanvasGroup>(), 0, 0.3f).setOnComplete(() => {
                                loading.gameObject.SetActive(false);
                                SetGameSetting();
                            }).setDelay(1.0f);
                        });
                    });
                }, false);
                break;
            case EState.Finish:
                fiberBar.gameObject.SetActive(false);
                LeanTween.moveLocalY(this.gameObject, -6.2f, 0.5f).setEaseInBack().setOnComplete(() => {
                    shake.MakeShake(10);

                    toMain.gameObject.SetActive(true);
                    LeanTween.alphaCanvas(toMain, 1, 0.4f).setDelay(0.7f);

                    score.gameObject.SetActive(true);
                    LeanTween.scale(score.gameObject, new Vector3(1, 1), 0.4f).setEaseInOutElastic();
                    LeanTween.alphaCanvas(score.GetComponent<CanvasGroup>(), 1.0f, 0.4f).setOnComplete(() => {
                        LeanTween.moveLocalY(score.gameObject,750, 0.4f).setEaseInExpo();
                    });
                });
                break;
            case EState.Fly:
                upAni.gameObject.SetActive(true);
                upAni.StartAnimation(upAni.GetComponent<SpriteRenderer>(), 0, 0, null, true);
                THHPManager.Instance.HPDamageStop();
                animation.StartAnimation(characterRenderer, (int)EState.Fly, 0.2f, null, true);

                level += 1; //레벨 업
                THHPManager.Instance.SetHPToLevel(level);
                

                if (!fiberBar.isFiberTime)
                {
                    fiberBar.gameObject.SetActive(false);
                    LeanTween.moveLocalY(characterRenderer.gameObject, 7.5f, 0.6f)
                    .setDelay(0.05f)
                    .setEaseOutBack()
                    .setOnComplete(() => {
                        upAni.gameObject.SetActive(false);
                        SetGameSetting();
                    });
                }
                break;
            default:
                break;
        }
    }
}
