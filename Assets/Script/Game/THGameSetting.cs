using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THGameSetting : MRSingleton<THGameSetting> {

    public float gameTime = 5f;     //체공시간

    public float addTimeToCombo1 = 0.5f;    //1콤보시 추가시간
    public float addTimeToCombo2 = 1.5f;    //2콤보시 추가시간
    public float addTimeToCombo3 = 2.5f;    //3콤보시 추가시간(예: 2.5초)

    public int feverCount = 5;    //5번 3콤보 성공시 피버
    
}
