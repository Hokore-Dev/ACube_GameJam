using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEngine : MonoBehaviour
{
    [SerializeField]
    Cubic[] cubic;

    [SerializeField]
    Player player;

    [SerializeField]
    FiberBar fiberBar;

    [SerializeField]
    Button fiberButton;

    [SerializeField]
    THIncreseNum txtMeter;

    // -2.5 ~ 3 (55)
    // 0 ~ -5 (50)
    private Vector2 START_POSITION = new Vector2(-2.5f, 0);

    List<Vector2> _positionIndex    = new List<Vector2>();
    List<int> _numberIndex          = new List<int>();
    List<int> _topNumberList = new List<int>();

    int meter = 0;
    int breakCount = 0;
    int score = 0;

    public void FeberTouch()
    {
        txtMeter.StartIncreseNum(meter += 100);
    }

    /// <summary>
    /// 큐빅을 터트렸을때
    /// </summary>
    /// <param name="score"></param>
    public void AddBreakCount(int score)
    {
        breakCount++;
        this.score += score;

        if (_topNumberList.Contains(score))
        {
            _topNumberList.Remove(score);
        }
        if (breakCount == 3)
        {
            for (int i = 0; i < cubic.Length; i++)
            {
                cubic[i].RemoveAnim(false);
            }
        }
    }

    /// <summary>
    /// 인게임 게이지가 모두 소모할때
    /// </summary>
    public void EndGameTime()
    {
        bool isFiber = false;
        // 최상위 숫자 3개를 모두 찾았을 때
        //if (_topNumberList.Count == 0)
        {
            isFiber = fiberBar.AddFiberCount();
        }
        if (isFiber)
        {
            fiberButton.gameObject.SetActive(true);
        }
        if (breakCount < 3)
        {
            for (int i = 0; i < cubic.Length; i++)
            {
                cubic[i].RemoveAnim(false);
            }
            txtMeter.StartIncreseNum(0);
            player.SetState(Player.EState.Finish);
        }
        else
        {
            txtMeter.StartIncreseNum(meter += score);
            player.SetState(Player.EState.Fly);
        }
        this.score = 0;
        breakCount = 0;
    }

    private void Start()
    {
        fiberBar.SetFiberCallback(() => {
            fiberButton.gameObject.SetActive(false);
            player.SetState(Player.EState.Fly);
        });

        for (int i = 0; i < cubic.Length; i++)
        {
            cubic[i].transform.parent.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetCubicRandomPosition();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            for (int i = 0; i < cubic.Length; i++)
            {
                cubic[i].RemoveAnim(false);
            }
            player.SetState(Player.EState.Finish);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            txtMeter.StartIncreseNum(meter += 300);
            player.SetState(Player.EState.Start);
        }
    }

    /// <summary>
    /// 공 배치의 실질적 위치를 가져온다.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    Vector2 GetRealPosition(int x, int y)
    {
        return new Vector2(-2.5f + (float)x / 10, 0 - (float)y / 10);
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
            // 3 * 3 자리에는 위치할 수 없게 제작한다.
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

    /// <summary>
    /// 중복되지 않는 랜덤 숫자를 생성한다 (1 ~ 100)
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// 최상위 3개의 숫자를 저장한다
    /// </summary>
    private void FindTopNumber()
    {
        _numberIndex.Sort();
        for (int i = 7;i > 4;i--)
        {
            _topNumberList.Add(_numberIndex[i]);
        }
    }

    /// <summary>
    /// 큐빅을 랜덤으로 위치 시킨다.
    /// </summary>
    public void SetCubicRandomPosition()
    {
        _positionIndex.Clear();
        _numberIndex.Clear();
        _topNumberList.Clear();

        for (int i = 0; i < cubic.Length; i++)
        {
            cubic[i].SetPosition(GetRandomPosition());
            cubic[i].SetNumber(GetRandomNumber());
            cubic[i].Appear();
        }
        FindTopNumber();
    }
}