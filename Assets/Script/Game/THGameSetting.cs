using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class THGameSetting : MRSingleton<THGameSetting> {

    [Header("최대 체력")]
    public int maxHP = 100;   //체력

    [Header("초당 체력 소모")]
    public int damageForPerSecond = 25; //25씩 체력 소모

    [Header("체력 회복")]
    public int[] healForCombo = new int[4] { 5, 40, 60, 70 };

    [Header("콤보당 상승높이")]
    public int[] heighForCombo = new int[4] { 25, 80, 125, 200};

    public int feverCount = 5;    //5번 3콤보 성공시 피버


    
}
