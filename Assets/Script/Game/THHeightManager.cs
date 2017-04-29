using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THHeightManager : MRSingleton<THHeightManager> {

    int currentHeight = 0;
    public int CurrentHeight { get { return currentHeight; } }
    public THIncreseNum uiHeight;

    public void SetHeight(int height_value)
    {
        currentHeight = height_value;
        uiHeight.StartIncreseNum(currentHeight);
    }

    public void AddHeight(int add_height_value)
    {
        currentHeight += add_height_value;
        uiHeight.StartIncreseNum(currentHeight);
    }

    public void AddHeight(int add_height_value, float duration)
    {
        currentHeight += add_height_value;
        uiHeight.StartIncreseNum(currentHeight, duration);
    }

    public void Drop()
    {
        uiHeight.StartIncreseNum(0);
    }
}
