using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int gameSpeed = 1;
    public int GameSpeed
    {
        get { return gameSpeed; }
        set { gameSpeed = value; }
    }

    private static GameManager instance;
    public static GameManager Instance
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
        UIManager.Instance.Init();
        S1_Car.Instance.Init();
        
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        if ( (gameTime < gameTimeMax) && !showCountTime )
        {
            UIManager.Instance.SetGameTimeText(" Time: " + gameTime.ToString("F2") + " s", true);
        }
        if ( !showCountTime && (gameTime >= gameTimeMax))
        {
            showCountTime = true;
            UIManager.Instance.SetGameTimeText(" Time: " + gameTime.ToString("F2") + " s", false);
        }

        if ((showCountTime) && (countTime > 0))
        {
            UIManager.Instance.SetCountTimeText(" Count: " + countTime.ToString("F0") + " s", true);
            Debug.Log("Count: " + countTime.ToString("F0") + " s");
            countTime -= Time.deltaTime;
        }


    }

    

}
