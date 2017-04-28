using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum EState
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
}
