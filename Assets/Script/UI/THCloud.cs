using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THCloud : MonoBehaviour {

    public float xPos;
    public float yMinPos;
    public float yMaxPos;

    float speed;
    bool move = false;
	// Use this for initialization
	void Start () {
        speed = Random.Range(10f, 20f);
    }

    public void InitPosition()
    {
        transform.localPosition = new Vector3(xPos, yMaxPos, 0f);
        float scaleFactor = Random.Range(1.0f, 1.5f);
        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
    }
	
	// Update is called once per frame
	void Update () {
		if(move)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime * 0.01f);
        }
	}

    public void SetMove(bool sm)
    {
        move = sm;
    }

    


}
