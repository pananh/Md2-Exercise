using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S1_Car : MonoBehaviour
{
    private Vector3 vector3Direction;
    private static S1_Car instance;
    public static S1_Car Instance
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
    public void Init()
    {
        vector3Direction = Vector3.forward;
    }

    void Update()
    {
        AutoMoveCar();
    }

    private void AutoMoveCar()
    {
        transform.Translate(vector3Direction * Time.deltaTime * GameManager.Instance.GameSpeed);

    }
}
