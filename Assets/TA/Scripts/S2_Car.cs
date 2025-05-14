using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S2_Car : MonoBehaviour
{
    private static S2_Car instance;
    public static S2_Car Instance
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
    }

    void Update()
    {
    }



    private void MoveCar(Vector3 vector3Point)
    {
        transform.Translate(vector3Direction * Time.deltaTime * S1_GM.Instance.GameSpeed);

        Vector3 dir = (this.transform.position - camera.transform.position).normalized
    }
}
