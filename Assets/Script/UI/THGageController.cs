using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.UI.Slider))]
public class THGageController : MonoBehaviour {

    protected Slider slider;

    [SerializeField]
    protected float maxValue;

    [SerializeField]
    protected float currentValue;

    [SerializeField]
    protected float addValueDuration;

	// Use this for initialization
	protected void Start () {
        slider = GetComponent<Slider>();
    }

    public void InitValue(float max_value, float current_value)
    {
        maxValue = max_value;
        currentValue = current_value;
    }

    public void InitValue(float max_value, bool full_gage = true)
    {
        if (full_gage)
            InitValue(max_value, max_value);
        else
            InitValue(max_value, 0);
    }

    public void SetValue(float current_value)
    {
        if(current_value > currentValue)    // 상승
        {
            LeanTween.value(currentValue, current_value, addValueDuration).setEaseInOutQuad().setOnUpdate(
            (float percent) =>
            {
                currentValue = percent;
             });
        }
        else
        {
            currentValue = current_value;
        }
    }

    protected void OnGUI()
    {
        slider.value = currentValue / maxValue;
        if (currentValue == 0)
            slider.fillRect.gameObject.SetActive(false);
        else
            slider.fillRect.gameObject.SetActive(true);
    }
}

