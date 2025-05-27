using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class S3_Car : MonoBehaviour
{
    private S3_Car instance;
    public S3_Car Instance
    {
        get
        {
            return instance;
        }
    }


    [SerializeField] private int speedGame;
    private float speedForce; 
    private float moveHorizontal, moveVertical;
    const string IpHor = "Horizontal";
    const string IpVer = "Vertical";
    Rigidbody rb;
    [SerializeField] Joystick joystick;


    void Awake()
    {
        speedGame = 100;
        speedForce = speedGame ;  // speedGame / 5f;
        instance = this;
        rb = GetComponent<Rigidbody>();
        moveHorizontal = 0f;
        moveVertical = 0f;
    }


    void Update()
    {
        moveHorizontal = Input.GetAxis(IpHor);
        moveVertical = Input.GetAxis(IpVer);
        if ((moveHorizontal != 0) || (moveVertical != 0))
        {
            MoveCar(new Vector3(moveHorizontal, 0, moveVertical) * speedGame * Time.deltaTime);
            //MoveCarByForce(new Vector3(moveHorizontal, 0, moveVertical) * speedForce * Time.deltaTime);
        }

        moveHorizontal = joystick.Horizontal;
        moveVertical = joystick.Vertical;

        if ( (moveHorizontal != 0) || (moveVertical != 0) )
        {
            MoveCar(new Vector3(moveHorizontal, 0 , moveVertical) * speedGame * Time.deltaTime );
            //MoveCarByForce(new Vector3(moveHorizontal, 0, moveVertical) * speedForce * Time.deltaTime);
        }

    }



    private void MoveCar(Vector3 direction)
    {
        transform.position += direction;
    }

    private void MoveCarByForce(Vector3 forceDirection)
    {
        //rb.AddForce(forceDirection, ForceMode.Impulse);
        rb.MovePosition(transform.position + forceDirection * 10);
    }
}




/*
   Rigidbody rb;
   [SerializeField] float Force = 20f;
   Vector3 vectorDirection = new Vector3(1, 0, 0);
   public LineRenderer lineRenderers;


   void Start()
   {
       rb = GetComponent<Rigidbody>();
       //rb.AddForce(vectorDirection * Force, ForceMode.Impulse); 
       //rb.AddForce(vectorDirection * Force, ForceMode.VelocityChange);
       //rb.AddForce(vectorDirection * Force, ForceMode.Force);        // có vẻ ko thấy hoạt động
       //rb.AddForce(vectorDirection * Force, ForceMode.Acceleration);     // có vẻ ko thấy hoạt động

   }

   void FixedUpdate()
   {
       //rb.AddForce(vectorDirection * Force, ForceMode.Impulse);        // đi nhanh do lực liên tục
       //rb.AddForce(vectorDirection * Force, ForceMode.VelocityChange);   // đi nhanh do lưc liên tục

       rb.AddForce(vectorDirection * Force, ForceMode.Force);      // hoạt động lực rất lung tung, 


       lineRenderers.SetPosition(lineRenderers.positionCount - 1, transform.position);



       //rb.AddForce(vectorDirection * Force, ForceMode.Acceleration);   // lực lên tròn khá mạnh



   } */





/*
lineRenderers.positionCount += 1;

lineRenderers.SetPosition(lineRenderers.positionCount - 1, transform.position);
public LineRenderer lineRenderers;


Rigidbody rb;
bool alreadyCollsionWithFloor;
public float hMax;

// Start is called before the first frame update
void Start()
{
    rb = GetComponent<Rigidbody>();
    rb.useGravity = true;
    rb.AddForce(new Vector3(100, 100, 0), ForceMode.VelocityChange);
    // rb.AddTorque()

    hMax = int.MinValue;

}

private void Update()
{

    lineRenderers.positionCount += 1;
    9h
    Hoàng Phạm Lê
20:15
8h50 - 8h55
Hoàng Phạm Lê
20:25
lineRenderers.SetPosition(lineRenderers.positionCount - 1, transform.position);    */