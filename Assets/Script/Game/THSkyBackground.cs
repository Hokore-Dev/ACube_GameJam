using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THSkyBackground : MRSingleton<THSkyBackground> {

    public Transform sky;

    public Sprite sky1;
    public Sprite sky2;
    public Sprite sky3;
    public Sprite fever;

    Sprite current_sky;
    bool nowFeverSky;

    public Vector3 initPosition;

    // Use this for initialization
    void Start () {
        RandomSky();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RandomSky()
    {
        switch(Random.Range(0,3))
        {
            case 0:
                current_sky = sky1;
                break;
            case 1:
                current_sky = sky2;
                break;
            case 2:
                current_sky = sky3;
                break;
        }
        sky.GetComponent<SpriteRenderer>().sprite = current_sky;
        transform.localPosition = initPosition;
    }

    public void StartFever()
    {
        nowFeverSky = true;
        sky.GetComponent<SpriteRenderer>().sprite = fever;
        sky.GetComponent<SpriteRenderer>().sortingOrder = 99;   //구름 가리기
    }

    public void EndFever()
    {
        nowFeverSky = false;
        sky.GetComponent<SpriteRenderer>().sprite = current_sky;
        sky.GetComponent<SpriteRenderer>().sortingOrder = 10;
    }

    public void Scroll(float duration, int jumpHight)
    {
        float yPos = transform.position.y;
        THCloudManager.Instance.StartCloud();
        LeanTween.moveY(gameObject, yPos - (jumpHight / 500f), duration).setOnComplete(() => {
            THCloudManager.Instance.StopCloud();
        });
    }

    public void StartBackground()
    {
        sky.gameObject.SetActive(true);
    }

    public void StopBackground()
    {
        sky.gameObject.SetActive(false);
    }
}
