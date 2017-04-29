using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    [SerializeField]
    GameObject []boss;

    [SerializeField]
    GameObject whatboss;

    public void Show()
    {
        HideWhatboss();
        boss[Random.Range(0, boss.Length)].SetActive(true);
    }

    public void HideWhatboss()
    {
        whatboss.SetActive(false);
    }
}
