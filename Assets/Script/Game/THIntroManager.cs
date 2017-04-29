using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THIntroManager : MRSingleton<THIntroManager> {

    
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject Title;

    public float duration = 1.0f;

    bool intro = true;
    bool title = false;
    bool leftEnd = false;
    bool rightEnd = false;

    private void Start()
    {
        LeanTween.alpha(Title, 1f, 1.5f);
    }

    private void Update()
    {
        if(!title)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Title.gameObject.SetActive(false);
                title = true;
            }
        }

        if (!intro)
            return;

        if (leftEnd && rightEnd)
            intro = false;

        if (Input.GetMouseButtonDown(0))
        {
            LeanTween.delayedCall(0.3f, () =>
            {
                LeanTween.moveX(leftWall, -12f, duration).setOnComplete(() => { leftWall.SetActive(false); leftEnd = true; });
                LeanTween.moveX(rightWall, 12f, duration).setOnComplete(() => { rightWall.SetActive(false); rightEnd = true; });
            });
        }
    }

    public bool IsIntro()
    {
        return intro;
    }

}
