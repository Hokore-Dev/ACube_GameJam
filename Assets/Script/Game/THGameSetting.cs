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
    public int heightPerKillMob = 150;

    [Header("뛰어오르는 시간")]
    public float heightMotionTime = 1.0f;

    public class Level
    {
        public int maxBreakCount;
        public int minBreakCount;
        public int maxNoneBreakCount;
        public int minNoneBreakCount;
        public bool forceFever = false;
    }
    
    public int GetLevelPart(int meter)
    {
        if (meter >= 0 && meter < 2500)
            return 0;
        if (meter >= 2500 && meter < 5000)
            return 1;
        if (meter >= 5000 && meter < 10000)
            return 2;
        if (meter >= 10000 && meter < 30000)
            return 3;
        if (meter >= 30000)
            return 4;
        return 1;
    }

    public List<Level> gameLevel = new List<Level>()
    {
        new Level() {   // Lv 1
            maxBreakCount = 4,
            minBreakCount = 3,
            maxNoneBreakCount = 3,
            minNoneBreakCount = 3
        },
        new Level() {   // Lv 2
            maxBreakCount = 5,
            minBreakCount = 4,
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
