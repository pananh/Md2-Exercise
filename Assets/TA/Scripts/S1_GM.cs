using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S1_GM : MonoBehaviour
{
    [SerializeField] private int gameSpeed = 1;
    public int GameSpeed
    {
        get { return gameSpeed; }
        set { gameSpeed = value; }
    }

    private static S1_GM instance;
    public static S1_GM Instance
    {
        get
        {
            return instance;
        }
    }

    private float gameTime;
    public float GameTime
    {
        get { return gameTime; }
        set { gameTime = value; }
    }

    private const int gameTimeMax = 10;

    private float countTime;
    public float CountTime
    {
        get { return countTime; }
        set { countTime = value; }
    }

    private bool showCountTime = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameTime = 0;
        countTime = 3;
        showCountTime = false;
        S1_UIManger.Instance.Init();
        S1_Car.Instance.Init();
        
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        if ( (gameTime < gameTimeMax) && !showCountTime )
        {
            S1_UIManger.Instance.SetGameTimeText(" Time: " + gameTime.ToString("F2") + " s", true);
        }
        if ( !showCountTime && (gameTime >= gameTimeMax))
        {
            showCountTime = true;
            S1_UIManger.Instance.SetGameTimeText(" Time: " + gameTime.ToString("F2") + " s", false);
        }

        if ((showCountTime) && (countTime >= 0))
        {
            S1_UIManger.Instance.SetCountTimeText(" Count: " + countTime.ToString("F0") + " s", true);
            countTime -= Time.deltaTime;
        }
        if (countTime <= 0)
        {
            S1_UIManger.Instance.SetCountTimeText(" Count: " + countTime.ToString("F0") + " s", false);
        }

    }

    

}
