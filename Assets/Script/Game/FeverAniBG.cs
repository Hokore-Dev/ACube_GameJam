using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverAniBG : MonoBehaviour {

    ImageAnimation animation;
    private void Awake()
    {
        animation = GetComponent<ImageAnimation>();
    }

    public void StartAni()
    {
        this.gameObject.SetActive(true);
        animation.StartAnimation(this.GetComponent<SpriteRenderer>(), 0, 0, null, true);
    }

    public void StopAni()
    {
        this.gameObject.SetActive(false);
    }
}
