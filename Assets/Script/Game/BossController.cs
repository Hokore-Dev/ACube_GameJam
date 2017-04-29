using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

    [SerializeField]
    GameObject []boss;

    public void Show()
    {
        boss[Random.Range(0, boss.Length)].SetActive(true);
    }
}
