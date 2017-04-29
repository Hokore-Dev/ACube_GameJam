using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THCloudManager : MRSingleton<THCloudManager> {

    public float minYPos = -120f;
    public float maxYPos = 120f;
    public float nextPos = 10f;

    public GameObject leftCloud;
    public GameObject rightCloud1;
    public GameObject rightCloud2;

    bool isStart = false;


    // Use this for initialization
    void Start () {
        StartCoroutine("CreateCloud");
    }
	
	// Update is called once per frame
	void Update () {
		if(isStart)
        {
            for(int i=0;i<transform.childCount;i++)
            {
                transform.GetChild(i).GetComponent<THCloud>().SetMove(true);
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<THCloud>().SetMove(false);
            }
        }
	}

    public void StartCloud()
    {
        isStart = true;
        StopCoroutine("CreateCloud");
        StartCoroutine("CreateCloud");
        
    }

    public void StopCloud()
    {
        isStart = false;
        StopCoroutine("CreateCloud");
    }

    void CreateClouds()
    {
        if(Random.Range(0f,1f) >= 0.7f)
        {
            GameObject lcloud = Instantiate<GameObject>(leftCloud);
            lcloud.transform.parent = transform;
            lcloud.transform.localScale = Vector3.one;
            lcloud.GetComponent<THCloud>().InitPosition();
        }

        if (Random.Range(0f, 1f) >= 0.7f)
        {
            if (Random.Range(0f, 1f) >= 0.5f)
            {
                GameObject rcloud = Instantiate<GameObject>(rightCloud1);
                rcloud.transform.parent = transform;
                rcloud.transform.localScale = Vector3.one;
                rcloud.GetComponent<THCloud>().InitPosition();
            }
            else
            {
                GameObject rcloud = Instantiate<GameObject>(rightCloud2);
                rcloud.transform.parent = transform;
                rcloud.transform.localScale = Vector3.one;
                rcloud.GetComponent<THCloud>().InitPosition();
            }
        }
    }

    public void AllClear()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    IEnumerator CreateCloud()
    {
        while(true)
        {
            if(isStart)
            {
                CreateClouds();
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    
}
