using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    Camera camera;

    [SerializeField]
    Shake shake;

    public enum EState
    {
        Up,
        Wait,
        Shoot,
    }

    private EState state = EState.Wait;
    private SpriteRenderer characterRenderer;

    private void Awake()
    {
        characterRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetState(EState state)
    {
        switch (state)
        {
            case EState.Up:
                break;
            case EState.Wait:
                break;
            case EState.Shoot:
                LeanTween.moveLocalY(this.gameObject, -3, 0.5f).setEaseInBack().setOnComplete(() => {
                    shake.MakeShake(5);
                });
                break;
            default:
                break;
        }
    }
}
