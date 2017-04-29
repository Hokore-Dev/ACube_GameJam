using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubic : MonoBehaviour
{
    [SerializeField]
    GameEngine gameEngine;

    [SerializeField]
    Sprite noneBreakSprite;

    [SerializeField]
    Sprite breakSprite;

    private bool canBreak;

    private const float SCALE_VALUE = 0.5f;
    private const int FONT_SIZE = 70;

    private SpriteRenderer renderer;
    private bool isAnimating = false;

    public void Awake()
    {
        renderer = this.transform.FindChild("Cubic").GetComponent<SpriteRenderer>();
    }

    public void SetBreak(bool isBreak)
    {
        canBreak = isBreak;
        renderer.sprite = (canBreak) ? breakSprite : noneBreakSprite;
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
        LeanTween.scale(renderer.gameObject, new Vector3(0, 0, 1), 0.1f).setOnComplete(() => {
            this.transform.parent.gameObject.SetActive(false);
            if (touchRemove)
                gameEngine.AddBreakCount(canBreak);
        });
    }

    private void OnMouseDown()
    {
        if (this.transform.parent.gameObject.activeSelf && !isAnimating)
        {
            RemoveAnim(true);
        }
    }
}
