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
    private Vector3 destinationCar, destinationByCamera;
    private Camera cameraCar;
    [SerializeField] private float speed;
    private bool checkDestinationCar;

    void Awake()
    {
        instance = this;
        cameraCar = Camera.main;
        speed = 10f;
        destinationCar = transform.position;
        checkDestinationCar = true;
    }

    void Start()
    {
       


    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            destinationCar = Input.mousePosition;

            Debug.Log("Mouse Screen: " + destinationCar);

            destinationByCamera = cameraCar.ScreenToWorldPoint(destinationCar);

            destinationCar.x = destinationByCamera.x + destinationCar.x;
            destinationCar.y = destinationByCamera.y + destinationCar.y;
            destinationCar.z = 0;

            checkDestinationCar = false;

            Debug.Log("Wordl Position" + destinationCar);
        }
        if (!checkDestinationCar)
        {
            MoveCar(destinationCar);
        }

    }



    private void MoveCar(Vector3 destination)
    {
        if (transform.position == destination)
        {
            checkDestinationCar = true;
            return;
        }

        transform.Translate(Time.deltaTime * speed * (destination - transform.position).normalized);

    }
}
