using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THHPManager : MRSingleton<THHPManager> {

    float currentHP = 0;
    float currentTime = 0f;

    public int CurrentHP { get { return (int)currentHP;  }  }

    public THImageGageController UIHPGage;

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
                HPDamageStop();
                //게임 오버처리 필요..
            }
            UIHPGage.SetValue(currentHP);
        }
	}

    public void Init()
    {
        currentHP = THGameSetting.Instance.maxHP;
        UIHPGage.InitValue(currentHP);
    }

    public void HPDamageStart()
    {
        state = State.RUN;
    }

    public void HPDamageStop()
    {
        state = State.READY;
    }

    public void SetHPToLevel(int level)
    {
        currentHP = THGameSetting.Instance.maxHP;
        currentHP -= THGameSetting.Instance.damageForLevel * (level - 1);
        UIHPGage.SetValue(currentHP, THGameSetting.Instance.heightMotionTime);
    }

    public void ZeroHP()
    {
        currentHP = 0;
        HPDamageStop();
        UIHPGage.SetValue(currentHP);
    }
}
