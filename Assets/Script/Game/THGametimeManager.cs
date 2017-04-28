using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THGametimeManager : MRSingleton<THGametimeManager> {

    float currentTime = 0f;
    public float CurrentTime { get { return currentTime;  }  }

    public THGageController UIGametimeGage;
    
    enum State
    {
        READY,
        RUN,
    }
    State state = State.READY;
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(state == State.RUN)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0f)
            {
                currentTime = 0f;               
                //게임 오버처리 필요..
            }
            UIGametimeGage.SetValue(currentTime);
        }
	}

    public void Init()
    {
        currentTime = THGameSetting.Instance.gameTime;
        UIGametimeGage.InitValue(THGameSetting.Instance.gameTime);
        state = State.RUN;
    }

    public void DidCombo(int comboCount)    //콤보 수행시 시간 올라감
    {
        switch(comboCount)
        { 
            case 1:
                currentTime += THGameSetting.Instance.addTimeToCombo1;                
                break;
            case 2:
                currentTime += THGameSetting.Instance.addTimeToCombo2;
                break;
            case 3:
                currentTime += THGameSetting.Instance.addTimeToCombo3;
                break;
        }
        currentTime = Mathf.Clamp(currentTime, 0f, THGameSetting.Instance.gameTime);
        UIGametimeGage.SetValue(currentTime);
    }





}
