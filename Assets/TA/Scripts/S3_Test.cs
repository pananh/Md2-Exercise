using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class S3_Test : MonoBehaviour
{
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





    }



}


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