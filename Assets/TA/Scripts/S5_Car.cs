using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class S5_Car : MonoBehaviour
{
    private S5_Car instance;
    public S5_Car Instance
    {
        get
        {
            return instance;
        }
    }
    [SerializeField] private int speedGame;
 
    GameObject [] wayPoint;
    List <int> wayPointIndex;
    int wayPointIndexCurrent = 0;
    Vector3 startPos, nextPos, endPos;
    float factorStartToEnd;
    float distanceSE;


    void Awake()
    {
        speedGame = 100;
        instance = this;
        MakeWayPointIndex();
        wayPointIndexCurrent = 0;
        factorStartToEnd = 0.0f;
    }

    void Start()
    {
        startPos = transform.position;
        endPos = wayPoint[wayPointIndex[wayPointIndexCurrent]].transform.position;
        distanceSE = Vector3.Distance(startPos, endPos);
    }

    void Update()
    {
        MoveCarAuto();
    }

    private void MoveCarAuto()
    {
        if (CheckMeet(wayPoint[wayPointIndex[wayPointIndexCurrent]].transform.position, transform.position))
        {
            wayPointIndexCurrent++;
            if (wayPointIndexCurrent >= wayPointIndex.Count)
            {
                wayPointIndexCurrent = 0;
            }
            startPos = transform.position;
            endPos = wayPoint[wayPointIndex[wayPointIndexCurrent]].transform.position;
            factorStartToEnd = 0;
            distanceSE = Vector3.Distance(startPos, endPos);

        }
        else
        {
            factorStartToEnd += Time.deltaTime * speedGame / distanceSE;
            if (factorStartToEnd > 1.0f)
            {
                factorStartToEnd = 1.0f;
            }
            //nextPos = Vector3.Lerp(startPos, endPos, factorStartToEnd);
            nextPos = Vector3.Slerp(startPos, endPos, factorStartToEnd);
            Debug.DrawLine(transform.position, nextPos, Color.red, 10f, true);
            transform.position = nextPos;
            
        }

    }


    private static bool CheckMeet(Vector3 destination1, Vector3 destination2)
    {
        Vector3 distance = destination1 - destination2;
        if (distance.sqrMagnitude < 0.1f)
        {
            return true;
        }
        return false;
    }

    private void MakeWayPointIndex()
    {
        wayPoint = GameObject.FindGameObjectsWithTag("WayPoint");
        double minDistance = float.MaxValue;
        Vector3 distanceVector;
        float distance;
        wayPointIndex = new List<int>();
        wayPointIndex.Add(-1);
        for (int i = 0; i < wayPoint.Length; i++)
        {
            distanceVector = wayPoint[i].transform.position - transform.position;
            distance = distanceVector.sqrMagnitude; 

            if (minDistance > distance)
            {
                minDistance = distance;
                wayPointIndex[0] = i;
            }
        }
        int index = 0;

        while (index < (wayPoint.Length - 1))
        {
            minDistance = float.MaxValue;
            wayPointIndex.Add(-1);

            for (int i = 0; i < wayPoint.Length; i++)
            {
                if (wayPointIndex.Contains(i))
                {
                    continue;
                }

                distanceVector = wayPoint[i].transform.position - wayPoint[wayPointIndex[index]].transform.position;
                distance = distanceVector.sqrMagnitude;
                if (minDistance > distance)
                {
                    minDistance = distance;
                    wayPointIndex[index + 1] = i;
                }
            }
            index++;
        }
    }

}




/*   
    private float moveHorizontal, moveVertical;
    const string IpHor = "Horizontal";
    const string IpVer = "Vertical";
    private void MoveCarByKey()
    {
        moveHorizontal = Input.GetAxis(IpHor);
        moveVertical = Input.GetAxis(IpVer);
        if ((moveHorizontal != 0) || (moveVertical != 0))
        {
            MoveCar(new Vector3(moveHorizontal, 0, moveVertical) * speedGame * Time.deltaTime);
        }
    }

*/




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