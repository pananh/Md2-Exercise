using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    private Vector3 mousePos, destinationPos;
    private Camera cameraCar;
    [SerializeField] private float speed;
   

    void Awake()
    {
        instance = this;
        cameraCar = Camera.main;
        speed = 15f;
        destinationPos = transform.position;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            Debug.Log("Mouse Screen: " + mousePos);
            mousePos.z = 10;

            destinationPos = cameraCar.ScreenToWorldPoint(mousePos);
            Debug.Log("World Position: " + mousePos);
        }
        MoveCar(destinationPos);
    }



    private void MoveCar(Vector3 destination)
    {
        // VECTOR3.DOT  // CHECK DISTANCE

        Vector3 direction = destination - transform.position;
        float x = direction.sqrMagnitude;
        if (x < 0.1f)
        {
            return;
        }
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
