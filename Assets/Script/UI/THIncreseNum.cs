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

    [SerializeField]
    private float duration = 0.5f;

    Text numText;
    // Use this for initialization
    void Start () {
        numText = GetComponent<Text>();
        StartIncreseNum(5000);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartIncreseNum(int target)
    {
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
