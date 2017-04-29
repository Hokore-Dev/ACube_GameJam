using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THHPGage : THGageController
{
    public Color manyHP;
    public Color midumeHP;
    public Color minHP;

	// Use this for initialization
	new void Start () {
        base.Start();
	}

    new void OnGUI()
    {
        HPColorChange();
        base.OnGUI();
    }

    void HPColorChange()
    {
        float currentHPRate = (float)THHPManager.Instance.CurrentHP / (float)THGameSetting.Instance.maxHP;
        Debug.Log(currentHPRate);
        if (currentHPRate > 0.7f)
        {
            slider.fillRect.GetComponent<UnityEngine.UI.Image>().color = manyHP;
        }
        else if (currentHPRate > 0.3f)
        {
            slider.fillRect.GetComponent<UnityEngine.UI.Image>().color = midumeHP;
        }
        else
        {
            slider.fillRect.GetComponent<UnityEngine.UI.Image>().color = minHP;
        }
    }
}
