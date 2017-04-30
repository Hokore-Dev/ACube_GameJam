using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    [SerializeField]
    GameObject []boss;

    [SerializeField]
    GameObject whatboss;

    int _index = -1;

    public void Show()
    {
        if (_index != -1)
            return;

        HideWhatboss();
        _index= Random.Range(0, boss.Length);
        for (int i = 0; i< boss.Length;i++)
        {
            boss[i].SetActive(i == _index);
        }
    }

    public void HideWhatboss()
    {
        whatboss.SetActive(false);
    }
}
