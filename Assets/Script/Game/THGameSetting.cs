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
            maxBreakCount = 4,
            minBreakCount = 4,
            maxNoneBreakCount = 2,
            minNoneBreakCount = 1
        },
        new Level() {   // Lv 2
            maxBreakCount = 4,
            minBreakCount = 4,
            maxNoneBreakCount = 2,
            minNoneBreakCount = 1
        },
        new Level() {   // Lv 3
            maxBreakCount = 4,
            minBreakCount = 4,
            maxNoneBreakCount = 2,
            minNoneBreakCount = 1,
            forceFever = true
        },
        new Level() {   // Lv 4
            maxBreakCount = 4,
            minBreakCount = 4,
            maxNoneBreakCount = 2,
            minNoneBreakCount = 1
        },
        new Level() {   // Lv 5
            maxBreakCount = 4,
            minBreakCount = 4,
            maxNoneBreakCount = 2,
            minNoneBreakCount = 1
        },
        new Level() {   // Lv 6
            maxBreakCount = 4,
            minBreakCount = 3,
            maxNoneBreakCount = 2,
            minNoneBreakCount = 1
        },
        new Level() {   // Lv 7
            maxBreakCount = 4,
            minBreakCount = 3,
            maxNoneBreakCount = 2,
            minNoneBreakCount = 1
        },
        new Level() {   // Lv 8
            maxBreakCount = 4,
            minBreakCount = 3,
            maxNoneBreakCount = 2,
            minNoneBreakCount = 1,
            forceFever = true
        },
        new Level() {   // Lv 9
            maxBreakCount = 4,
            minBreakCount = 3,
            maxNoneBreakCount = 2,
            minNoneBreakCount = 1
        },
        new Level() {   // Lv 10
            maxBreakCount = 4,
            minBreakCount = 3,
            maxNoneBreakCount = 2,
            minNoneBreakCount = 1
        },
        new Level() {   // Lv 11
            maxBreakCount = 3,
            minBreakCount = 3,
            maxNoneBreakCount = 4,
            minNoneBreakCount = 2
        },
        new Level() {   // Lv 12
            maxBreakCount = 3,
            minBreakCount = 3,
            maxNoneBreakCount = 4,
            minNoneBreakCount = 2
        },
        new Level() {   // Lv 13
            maxBreakCount = 3,
            minBreakCount = 3,
            maxNoneBreakCount = 4,
            minNoneBreakCount = 2,
            forceFever = true
        },
        new Level() {   // Lv 14
            maxBreakCount = 3,
            minBreakCount = 3,
            maxNoneBreakCount = 4,
            minNoneBreakCount = 2
        },
        new Level() {   // Lv 15
            maxBreakCount = 3,
            minBreakCount = 3,
            maxNoneBreakCount = 4,
            minNoneBreakCount = 2
        },
        new Level() {   // Lv 16
            maxBreakCount = 3,
            minBreakCount = 2,
            maxNoneBreakCount = 4,
            minNoneBreakCount = 3
        },
        new Level() {   // Lv 17
       maxBreakCount = 3,
            minBreakCount = 2,
            maxNoneBreakCount = 4,
            minNoneBreakCount = 3
        },
        new Level() {   // Lv 18
            maxBreakCount = 3,
            minBreakCount = 2,
            maxNoneBreakCount = 4,
            minNoneBreakCount = 3,
            forceFever = true
        },
        new Level() {   // Lv 19
            maxBreakCount = 3,
            minBreakCount = 2,
            maxNoneBreakCount = 4,
            minNoneBreakCount = 3
        },
        new Level() {   // Lv 20
            maxBreakCount = 3,
            minBreakCount = 2,
            maxNoneBreakCount = 4,
            minNoneBreakCount = 3
        },
        new Level() {   // Lv 21
            maxBreakCount = 2,
            minBreakCount = 2,
            maxNoneBreakCount = 6,
            minNoneBreakCount = 5
        },
        new Level() {   // Lv 22
    maxBreakCount = 2,
            minBreakCount = 2,
            maxNoneBreakCount = 6,
            minNoneBreakCount = 5
        },
        new Level() {   // Lv 23
        maxBreakCount = 2,
            minBreakCount = 2,
            maxNoneBreakCount = 6,
            minNoneBreakCount = 5,
            forceFever = true
        },
        new Level() {   // Lv 24
             maxBreakCount = 2,
            minBreakCount = 2,
            maxNoneBreakCount = 6,
            minNoneBreakCount = 5
        },
        new Level() {   // Lv 25
     maxBreakCount = 2,
            minBreakCount = 2,
            maxNoneBreakCount = 6,
            minNoneBreakCount = 5
        },
        new Level() {   // Lv 26
            maxBreakCount = 1,
            minBreakCount = 1,
            maxNoneBreakCount = 7,
            minNoneBreakCount = 6
        },
        new Level() {   // Lv 27
            maxBreakCount = 1,
            minBreakCount = 1,
            maxNoneBreakCount = 7,
            minNoneBreakCount = 6
        },
        new Level() {   // Lv 28
            maxBreakCount = 1,
            minBreakCount = 1,
            maxNoneBreakCount = 7,
            minNoneBreakCount = 6,
            forceFever = true
        },
        new Level() {   // Lv 29
            maxBreakCount = 1,
            minBreakCount = 1,
            maxNoneBreakCount = 7,
            minNoneBreakCount = 6
        },
        new Level() {   // Lv 30
            maxBreakCount = 1,
            minBreakCount = 1,
            maxNoneBreakCount = 7,
            minNoneBreakCount = 6
        },
    };
    
}
