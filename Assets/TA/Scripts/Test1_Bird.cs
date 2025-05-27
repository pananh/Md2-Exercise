using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class Test1_Bird : MonoBehaviour
{
    public static Test1_Bird instance;

    private int speedGame;
    public Vector3 startPos, nextPos, endPos;
    float factorStartToEnd;
    public float distanceSE;
    public bool isMoving = false;



    void Awake()
    {
        instance = this;
        speedGame = 50;
        factorStartToEnd = 0.0f;
        isMoving = false;
    }

    void Start()
    {
        startPos = transform.position;
        endPos = new Vector3(-500,10,10);
        distanceSE = Vector3.Distance(startPos, endPos);
    }

    void Update()
    {
        if (isMoving)
        {
            MoveBird();

        }
    }

    private void MoveBird()
    {
        factorStartToEnd += Time.deltaTime * distanceSE * speedGame / 100000;
        //if (factorStartToEnd > 1.0f)
        //{
        //    factorStartToEnd = 1.0f;
        //}
        
        //nextPos = Vector3.Lerp(startPos, endPos, factorStartToEnd);
        //nextPos = Vector3.Slerp(startPos, endPos, factorStartToEnd);
        nextPos = transform.position + (endPos - startPos).normalized * factorStartToEnd;

        Debug.DrawLine(transform.position, nextPos, Color.red, 10f, true);
        transform.position = nextPos;

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            Debug.Log("Bird hit the wall");
            Time.timeScale = 0.0f;
            //Destroy(other.gameObject);
        }
    }


}



