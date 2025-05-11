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

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        S1_Car.Instance.Init();

    }

    void Update()
    {
        
    }

    

}
