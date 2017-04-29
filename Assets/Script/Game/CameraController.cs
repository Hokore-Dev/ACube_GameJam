using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera camera;
    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    public void ShowFarAway()
    {
 
    }
}
