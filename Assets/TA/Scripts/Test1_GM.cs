using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1_GM : MonoBehaviour
{
    private Vector3 mStart = new Vector3(0, 0, 0);
    private Vector3 mEnd = new Vector3(0, 0, 0);
    private float distanceSE;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mStart = Input.mousePosition;
        }
        else 
        if (Input.GetMouseButtonUp(0))
        {
            mEnd = Input.mousePosition;
            Debug.DrawLine(mStart, mEnd, Color.blue, 10f, true);
        }
        distanceSE = Vector3.Distance(mStart, mEnd);

        if ((distanceSE > 0.5f) && (Test1_Bird.instance != null) && (Test1_Bird.instance.isMoving == false))
        {
            if (distanceSE > 100f)
            {
                distanceSE = 100f;
            }
            Test1_Bird.instance.isMoving = true;
            Test1_Bird.instance.startPos = mStart;
            Test1_Bird.instance.endPos = mEnd;
        }


        


    }
}
