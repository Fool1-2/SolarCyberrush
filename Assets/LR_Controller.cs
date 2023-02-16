using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR_Controller : MonoBehaviour
{
    public Transform[] points;
    public Transform OPoint;
    public Transform CPoint;
    public int currentPointNum;
    public LR_Controller lr;
    public int pointsAmount;
    public float pointSize;
    //public PipeControllerScript pipeCon;
    public bool iscon;
    public GameObject TS;

    private void Start() {
        if (Vector2.Distance(transform.position, TS.transform.position) < 3.5f)
        {
            TS.GetComponent<TestScrpt>().LR = this.GetComponent<LR_Controller>();
        }

        pointsAmount = points.Length;
    }

    private void OnDrawGizmos() {
        pointsAmount = points.Length;

        if (!iscon)
        {
            foreach (Transform point in points)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(point.position, pointSize);
            }
    
            for (int i = 0; i < pointsAmount - 1; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(points[i].position, points[i + 1].position);
            }
        }
        else
        {
            foreach (Transform point in lr.points)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    if (Vector2.Distance(points[i].position, point.position) < 2)
                    {
                        OPoint = points[i];
                        CPoint = point;
                        Gizmos.color = Color.red;
                        Gizmos.DrawLine(OPoint.position, CPoint.position);
                        break;
                    }
                }
            }

            foreach (Transform point in points)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawWireSphere(point.position, pointSize);
            }
    
            for (int i = 0; i < pointsAmount - 1; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(points[i].position, points[i + 1].position);
            }
        }
    }

    private void Update() {
        if (Vector2.Distance(transform.position, TS.transform.position) < 3.5f)
        {
            TS.GetComponent<TestScrpt>().LR = this.GetComponent<LR_Controller>();
        }
    }

    public void GetNextPoint(Transform currentPoint, Transform currentGameObject)
    {
        if (currentPoint == points[currentPointNum])
        {
            currentPoint = points[currentPointNum + 1];
            
        }
    }
}
