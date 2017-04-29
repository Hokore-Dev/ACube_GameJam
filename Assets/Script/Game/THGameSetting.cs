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

    [Header("게임 단계높이")]
    public int[] heightLevel = new int[5] { 1000, 5000, 10000, 15000, 20000 };

    public int feverCount = 5;    //5번 3콤보 성공시 피버

    public class Level
    {
        public int maxBreakCount;
        public int minBreakCount;
        public int maxNoneBreakCount;
        public int minNoneBreakCount;
        public bool forceFever = false;
    }

    public List<Level> gameLevel = new List<Level>()
    {
        new Level() {   // Lv 1
            maxBreakCount = 5,
            minBreakCount = 3,
            maxNoneBreakCount = 3,
            minNoneBreakCount = 3
        },
        new Level() {   // Lv 2
            maxBreakCount = 6,
            minBreakCount = 5,
            maxNoneBreakCount = 4,
            minNoneBreakCount = 3
        },
        new Level() {   // Lv 3
            maxBreakCount = 7,
            minBreakCount = 6,
            maxNoneBreakCount = 5,
            minNoneBreakCount = 4,
        },
        new Level() {   // Lv 4
            maxBreakCount = 7,
            minBreakCount = 6,
            maxNoneBreakCount = 6,
            minNoneBreakCount = 4
        },
        new Level() {   // Lv 5
            maxBreakCount = 8,
            minBreakCount = 7,
            maxNoneBreakCount = 6,
            minNoneBreakCount = 4
        }
    };
    
}
