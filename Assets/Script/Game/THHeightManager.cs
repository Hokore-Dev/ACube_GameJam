using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THHeightManager : MRSingleton<THHeightManager> {

    int currentHeight = 0;
    public int CurrentHeight { get { return currentHeight; } }
    public THIncreseNum uiHeight;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DidCombo(int comboCount)    //콤보 수행시 시간 올라감
    {
        currentHeight += THGameSetting.Instance.heighForCombo[comboCount];
        uiHeight.StartIncreseNum(currentHeight);
    }

    public void Drop()
    {
        uiHeight.StartIncreseNum(0);
    }
}
