using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THHPImageGageController : THImageGageController {

    public Color minHPColor;
    public Color midumeHPColor;
    public Color manyHPColor;

    new void OnGUI()
    {
        base.OnGUI();
        if (valueImage.fillAmount > 0.7f)
            valueImage.color = manyHPColor;
        else if (valueImage.fillAmount > 0.4f)
            valueImage.color = midumeHPColor;
        else
            valueImage.color = minHPColor;
    }
}
