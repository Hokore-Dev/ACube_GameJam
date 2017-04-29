using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.UI.Slider))]
public class THGageController : MonoBehaviour {

    protected Slider slider;

    [SerializeField]
    private GameEngine gameEngine;

    [SerializeField]
    protected float maxValue;

    [SerializeField]
    protected float currentValue;

    public bool isRun = false;
    private bool callRequest = false;

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
        callRequest = false;
        if (full_gage)
            InitValue(max_value, max_value);
        else
            InitValue(max_value, 0);
    }

    public void SetValue(float current_value, float duration = 0f)
    {
        if(duration > 0f)    // 상승
        {
            LeanTween.value(currentValue, current_value, duration).setEaseInOutQuad().setOnUpdate(
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
        isRun = !(currentValue == 0);
        if (currentValue == 0)
        {
            if (!callRequest)
            {
                gameEngine.EndGameTime();
                callRequest = true;
            }
            slider.fillRect.gameObject.SetActive(false);
        }
        else
            slider.fillRect.gameObject.SetActive(true);
    }
}

