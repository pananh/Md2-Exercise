using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class S6_Ball : MonoBehaviour
{
    private S6_Ball instance;
    public S6_Ball Instance
    {
        get
        {
            return instance;
        }
    }

    float timeTotal = 0f;
    Vector3 startPos, endPos, tempPos;
    Rigidbody rb;
    [SerializeField] LineRenderer lineRenderer;
    bool onCollisionCheck = false;
    float yMax = float.MinValue;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Tắt trọng lực ngay từ đầu

    }

    void Start()
    {
        lineRenderer.positionCount = 0; // Đặt số lượng điểm ban đầu của LineRenderer là 0
    }

    void Update()
    {
        if (Time.time - timeTotal < 10f)
        {
            rb.useGravity = true;
        }
        else
        {
            rb.useGravity = false;
        }

        if (Vector3.Distance(startPos, transform.position) > 0.2f)
        {

            startPos = transform.position; // Cập nhật vị trí bắt đầu mỗi khi xe di chuyển
            lineRenderer.positionCount += 1; // Tăng số lượng điểm của LineRenderer mỗi lần Update;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position); // Cập nhật vị trí cuối cùng của LineRenderer
        }

        if (onCollisionCheck)
        {
            if (transform.position.y > yMax)
            {
                yMax = transform.position.y; // Cập nhật giá trị yMax nếu vị trí hiện tại lớn hơn yMax
                Debug.Log("Y Max: " + yMax);
            }
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        onCollisionCheck = true;
        
    }
}

   


