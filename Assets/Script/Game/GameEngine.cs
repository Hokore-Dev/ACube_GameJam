using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    [SerializeField]
    Cubic[] cubic;

    [SerializeField]
    Text testTotal;

    // -2.5 ~ 3 (55)
    // 1 ~ -5 (60)
    private Vector2 START_POSITION = new Vector2(-2.5f, 1f);

    List<Vector2> _positionIndex = new List<Vector2>();
    List<int> _numberIndex = new List<int>();

    int breakCount = 0;
    int score = 0;

    public void AddBreakCount(int score)
    {
        breakCount++;
        this.score += score;
        if (breakCount == 3)
        {
            testTotal.text = "Total : " + this.score.ToString();
            this.score = 0;
            breakCount = 0;
            SetCubicRandomPosition();
        }
    }


    private void Start()
    {
        SetCubicRandomPosition();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetCubicRandomPosition();
        }
    }

    Vector2 GetRealPosition(int x, int y)
    {
        return new Vector2(-2.5f + (float)x / 10, 1 - (float)y / 10);
    }

    /// <summary>
    /// 겹치지 않는 포지션을 선정하기 위함
    /// </summary>
    /// <returns></returns>
    Vector2 GetRandomPosition()
    {
        Vector2 position = Vector2.zero;
        int splitX = 4;
        int splitY = 4;
        int x = Random.Range(0, 55 / splitX) * splitX;
        int y = Random.Range(0, 60 / splitY) * splitY;
        position = GetRealPosition(x,y);
        if (!_positionIndex.Contains(position))
        {
            _positionIndex.Add(GetRealPosition(x - splitX, y - splitY));
            _positionIndex.Add(GetRealPosition(x - splitX, y));
            _positionIndex.Add(GetRealPosition(x - splitX, y + splitY));

            _positionIndex.Add(GetRealPosition(x + splitX, y - splitY));
            _positionIndex.Add(GetRealPosition(x + splitX, y));
            _positionIndex.Add(GetRealPosition(x + splitX, y + splitY));

            _positionIndex.Add(GetRealPosition(x, y + splitY));
            _positionIndex.Add(GetRealPosition(x, y - splitY));

            _positionIndex.Add(position);
            return position;
        }
        else
        {
            return GetRandomPosition();
        }
    }

    int GetRandomNumber()
    {
        int random = Random.Range(1, 100);
        if (!_numberIndex.Contains(random))
        {
            _numberIndex.Add(random);
            return random;
        }
        else
        {
            return GetRandomNumber();
        }
    }

    private void SetCubicRandomPosition()
    {
        _positionIndex.Clear();
        _numberIndex.Clear();

        for (int i = 0; i < cubic.Length; i++)
        {
            cubic[i].SetPosition(GetRandomPosition());
            cubic[i].SetNumber(GetRandomNumber());
            cubic[i].Appear();
        }
    }
}