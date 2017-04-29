using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EType
{
    Break,
    NoneBreak,
    Boss,
    Fever
}

public class Cubic : MonoBehaviour
{
    [SerializeField]
    GameEngine gameEngine;

    [SerializeField]
    Sprite noneBreakSprite;

    [SerializeField]
    Sprite breakSprite;

    [SerializeField]
    Sprite bossSprite;

    [SerializeField]
    Sprite feverSprite;

    private const float SCALE_VALUE = 0.5f;
    private const int FONT_SIZE = 70;

    private SpriteRenderer renderer;
    private bool isAnimating = false;
    private EType type = EType.Break;

    public void Awake()
    {
        renderer = this.transform.FindChild("Cubic").GetComponent<SpriteRenderer>();
        LeanTween.rotateX(this.gameObject, 30, 0.9f)
                .setEase(LeanTweenType.easeShake)
                .setRepeat(-1);
    }

    public void SetType(EType type)
    {
        this.type = type;
        switch (type)
        {
            case EType.Break:
                renderer.sprite = breakSprite;
                break;
            case EType.NoneBreak:
                renderer.sprite = noneBreakSprite;
                break;
            case EType.Boss:
                renderer.sprite = bossSprite;
                break;
            case EType.Fever:
                renderer.sprite = feverSprite;
                break;
            default:
                break;
        }
    }

    public void Appear()
    {
        isAnimating = false;
        this.transform.parent.gameObject.SetActive(true);
    }

    public void SetPosition(Vector2 vec2)
    {
        renderer.transform.localScale = new Vector3(0, 0, 1);
        this.transform.localPosition = vec2;

        float animationTime = 0.2f + Random.Range(0, 10) / 100 * 20;
        LeanTween.scale(renderer.gameObject, new Vector3(SCALE_VALUE, SCALE_VALUE, 1), animationTime).setEaseInOutQuad();
    }

    public void RemoveAnim(bool touchRemove = true)
    {
        isAnimating = true;
        LeanTween.scale(renderer.gameObject, new Vector3(1.4f, 1.4f, 1), 0.1f).setOnComplete(() => {
            this.transform.parent.gameObject.SetActive(false);
            renderer.color = new Color(1, 1, 1, 1); 
            if (touchRemove)
            {
                gameEngine.AddBreakCount(type);
            }
        });
        LeanTween.alpha(renderer.gameObject, 0, 0.1f);
    }

    private void OnMouseDown()
    {
        if (this.transform.parent.gameObject.activeSelf && !isAnimating)
        {
            if (type == EType.Boss)
            {
                gameEngine.AddBreakCount(type, this.gameObject);
            }
            else
            {
                RemoveAnim(true);
            }
        }
    }
}
