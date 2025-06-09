using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class S6_Bullet : MonoBehaviour
{

    [SerializeField] private Vector3 bulletVelocity = new Vector3(10f, 0, 0);
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LineRenderer lineRenderer2;

    private bool isTrigger = false;
    [SerializeField] LayerMask layer; 


    void Start()
    {
        lineRenderer.enabled = false;
        lineRenderer2.enabled = false;
    }

    void Update()
    {
        transform.position += bulletVelocity * Time.deltaTime;
        if ((isTrigger) && (lineRenderer.positionCount < 100))
        {
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);


            lineRenderer2.positionCount++;
            lineRenderer2.SetPosition(lineRenderer.positionCount - 1, transform.position + new Vector3 (0, 0, 1));

        }

        bool hit = Physics.Raycast(transform.position, bulletVelocity.normalized, out RaycastHit hitInfo, bulletVelocity.magnitude * Time.deltaTime, layer);
        if (hit)
        {
            Debug.Log("Bullet hit by Raycast: " + hitInfo.collider.gameObject.name);
            Debug.Log("Hit point: " + hitInfo.point + " distance " + hitInfo.distance);

            S6_7_UI.instance.StatusText = "Bullet hit by Raycast: " + hitInfo.collider.gameObject.name + " \n at point: " + hitInfo.point + " distance: " + hitInfo.distance;


            isTrigger = true;
            lineRenderer.enabled = true;
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, transform.position);

            lineRenderer2.enabled = true;
            lineRenderer2.positionCount = 1;
            lineRenderer2.SetPosition(0, hitInfo.point + new Vector3(0, 0, 1));

        }

    }

    void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log("Bullet hit by OnTrigger (thru): " + other.gameObject.name);
        //isTrigger = true;
        //lineRenderer.enabled = true;        lineRenderer.positionCount = 1;
        //lineRenderer.SetPosition(0, transform.position);

        // If the speed of the bullet is high enough, it may pass through objects without triggering collision events.. Example: 250 m/s
        //Debug.Break();

    }

    void OnCollisionEnter(Collision collision)
    {
         //Debug.Log("Bullet hit by Collision (dont thru): " + collision.gameObject.name);
    }

    
}
