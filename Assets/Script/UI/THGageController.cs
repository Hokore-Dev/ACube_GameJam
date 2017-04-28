using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.UI.Slider))]
public class THGageController : MonoBehaviour {

    protected Slider slider;
    protected int maxValue;
    protected int currentValue;

	// Use this for initialization
	protected void Start () {
        slider = GetComponent<Slider>();
    }

    public void InitValue(int max_value, int current_value)
    {
        maxValue = max_value;
        currentValue = current_value;
    }

    public void InitValue(int max_value, bool full_gage = true)
    {
        if (full_gage)
            InitValue(max_value, max_value);
        else
            InitValue(max_value, 0);
    }

    public void SetValue(int current_value)
    {
        currentValue = current_value;
    }

    protected void OnGUI()
    {
        slider.value = (float)((float)currentValue / (float)maxValue);
        if (currentValue == 0)
            slider.fillRect.gameObject.SetActive(false);
        else
            slider.fillRect.gameObject.SetActive(true);
    }
}

