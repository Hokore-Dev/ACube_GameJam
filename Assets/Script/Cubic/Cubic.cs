using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubic : MonoBehaviour {
    [SerializeField]
    GUIText text;

    [SerializeField]
    GameEngine gameEngine;

    private int number = 0;

    public void Appear()
    {
        this.transform.parent.gameObject.SetActive(true);
    }

    public void SetPosition(Vector2 vec2)
    {
        this.transform.localPosition = vec2;
        text.transform.localPosition = Camera.main.WorldToViewportPoint(transform.position);
    }

    public void SetNumber(int number)
    {
        this.number = number;
        text.text = number.ToString();
    }

    private void OnMouseDown()
    {
        if (this.transform.parent.gameObject.activeSelf)
        {
            this.transform.parent.gameObject.SetActive(false);
            gameEngine.AddBreakCount(number);
        }
    }
}
