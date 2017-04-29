using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubic : MonoBehaviour {
    [SerializeField]
    GUIText text;

    [SerializeField]
    GameEngine gameEngine;

    private const float SCALE_VALUE = 0.5f;
    private const int FONT_SIZE = 70;

    private SpriteRenderer renderer;
    private int number = 0;
    private bool isAnimating = false;

    public void Awake()
    {
        renderer = this.transform.FindChild("Cubic").GetComponent<SpriteRenderer>();
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
        text.transform.localPosition = Camera.main.WorldToViewportPoint(transform.position);
        text.color = new Color(0, 0, 0, 0); 

        float animationTime = 0.2f + Random.Range(0, 10) / 100 * 20;
        LeanTween.scale(renderer.gameObject, new Vector3(SCALE_VALUE, SCALE_VALUE, 1), animationTime).setEaseInOutQuad();
        LeanTween.value(0f, 1f, animationTime).setEaseInOutQuad().setOnUpdate(
            (float percent) =>
            {
                text.color = new Color(0, 0, 0, percent);
            });

        LeanTween.value(0f, FONT_SIZE, animationTime).setEaseInOutQuad().setOnUpdate(
            (float percent) =>
            {
                text.fontSize = (int)percent;
            });
    }

    public void SetNumber(int number)
    {
        this.number = number;
        text.text = number.ToString();
    }

    public void RemoveAnim(bool touchRemove = true)
    {
        isAnimating = true;
        LeanTween.scale(renderer.gameObject, new Vector3(0, 0, 1), 0.1f).setOnComplete(() => {
            this.transform.parent.gameObject.SetActive(false);
            if(touchRemove)
                gameEngine.AddBreakCount(number);
        });

        LeanTween.value(1f, 0f, 0.1f).setEaseInOutQuad().setOnUpdate(
            (float percent) =>
            {
                text.color = new Color(0, 0, 0, percent);
            });

        LeanTween.value(FONT_SIZE, 0, 0.1f).setEaseInOutQuad().setOnUpdate(
            (float percent) =>
            {
                text.fontSize = (int)percent;
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
