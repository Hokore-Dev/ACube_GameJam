using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THFeverGage : THGageController {

    new void Start()
    {
        base.Start();
        InitValue(100, false);
        AddFeverValue();
    }

    public void AddFeverValue()
    {
        LeanTween.value(0f, 20f, 2.0f).setEaseInOutQuad().setOnUpdate(
            (float percent) => 
            {
                currentValue = (int)percent;
            });
    }


}
