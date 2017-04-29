using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class THGameSetting : MRSingleton<THGameSetting> {

    [Header("최대 체력")]
    public int maxHP = 100;   //체력

    [Header("초당 체력 소모")]
    public int damageForPerSecond = 25; //25씩 체력 소모

    [Header("단계당 깎을 체력")]
    public int damageForLevel = 3;

    [Header("1몹당 상승높이")]
    public int heightPerKillMob = 100;

    [Header("뛰어오르는 시간")]
    public float heightMotionTime = 1.0f;
    
}
