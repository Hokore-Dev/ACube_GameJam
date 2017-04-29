using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THGametimeManager : MRSingleton<THGametimeManager> {

    float currentHP = 0;
    float currentTime = 0f;
    public int CurrentHP { get { return (int)currentHP;  }  }

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
            currentHP -= (THGameSetting.Instance.damageForPerSecond * Time.deltaTime);
            if(currentHP <= 0f)
            {
                currentHP = 0f;               
                //게임 오버처리 필요..
            }
            UIGametimeGage.SetValue(currentHP);
        }
	}

    public void Init()
    {
        currentHP = THGameSetting.Instance.maxHP;
        UIGametimeGage.InitValue(currentHP);
        state = State.RUN;
    }

    public void Stop()
    {
        state = State.READY;
    }

    public void DidCombo(int comboCount)    //콤보 수행시 시간 올라감
    {
        currentHP += THGameSetting.Instance.healForCombo[comboCount];
        currentHP = Mathf.Clamp(currentHP, 0f, THGameSetting.Instance.maxHP);
        UIGametimeGage.SetValue(currentHP);
    }





}
