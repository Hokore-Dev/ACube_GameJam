using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(UnityEngine.UI.Text))]
public class THIncreseNum : MonoBehaviour {

    [SerializeField]
    private int currentValue = 0;

    [SerializeField]
    private string addString = "";

    float duration = 0.0f;

    Text numText;
    // Use this for initialization
    void Start () {
        numText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartIncreseNum(int target)
    {
        this.duration = THGameSetting.Instance.heightMotionTime;
        StopCoroutine("CountTo");
        StartCoroutine("CountTo", target);
    }

    public void StartIncreseNum(int target, float duration)
    {
        this.duration = duration;
        StopCoroutine("CountTo");
        StartCoroutine("CountTo", target);
    }

    private void OnGUI()
    {
        numText.text = currentValue.ToString() + addString;
    }

    IEnumerator CountTo(int target)
    {
        int start = currentValue;
        for (float timer = 0; timer < duration; timer += Time.deltaTime)
        {
            float progress = timer / duration;
            currentValue = (int)Mathf.Lerp(start, target, progress);
            yield return null;
        }
        currentValue = target;
    }

}
