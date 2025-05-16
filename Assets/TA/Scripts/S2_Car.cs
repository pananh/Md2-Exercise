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
    private Vector3 mousePosition, destinationByCamera;
    private Camera cameraCar;
    [SerializeField] private float speed;
   

    void Awake()
    {
        instance = this;
        cameraCar = Camera.main;
        speed = 10f;
        destinationByCamera = transform.position;

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;

            Debug.Log("Mouse Screen: " + mousePosition);

  
            mousePosition.z = 10;

            destinationByCamera = cameraCar.ScreenToWorldPoint(mousePosition);

            Debug.Log("World Position" + mousePosition);
        }

        MoveCar(destinationByCamera);
    }



    private void MoveCar(Vector3 destination)
    {
        // VECTOR3.DOT  \\ CHECK DISTANCE

        Vector3 direction = destination - transform.position;

        float x = direction.sqrMagnitude;
        if (x < 0.1f)
        {
            return;
        }

        transform.position += direction.normalized * speed * Time.deltaTime;
        Debug.Log("Car Position: " + transform.position);
    }
}
