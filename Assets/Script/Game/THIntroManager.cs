using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THIntroManager : MRSingleton<THIntroManager> {

    
    public GameObject leftWall;
    public GameObject rightWall;

    public float duration = 1.0f;

    bool intro = true;
    bool leftEnd = false;
    bool rightEnd = false;

    private void Update()
    {
        if (!intro)
            return;

        if (leftEnd && rightEnd)
            intro = false;

        if (Input.GetMouseButtonDown(0))
        {
            LeanTween.moveX(leftWall, -12f, duration).setOnComplete(() => { leftWall.SetActive(false); leftEnd = true; });
            LeanTween.moveX(rightWall, 12f, duration).setOnComplete(() => { rightWall.SetActive(false); rightEnd = true; });
        }
    }

    public bool IsIntro()
    {
        return intro;
    }
}
