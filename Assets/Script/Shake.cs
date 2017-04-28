using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public void MakeShake(float count)
    {
        float distance = count / 20;
        float time = count / 20;
        LeanTween.moveX(this.gameObject, (count % 2 == 0) ? distance : -distance, time).setEaseShake().setOnComplete(() =>
        {
        });
    }
}
