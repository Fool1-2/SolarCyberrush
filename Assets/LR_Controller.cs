using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LR_Controller : MonoBehaviour
{
    public Transform[] points;
    public PipeControllerScript[] pipeCon;
    public Transform OPoint;
    public Transform CPoint;
    public List<LR_Controller> lr;
    public int pointsAmount;
    public float pointSize;
    public bool iscon;
    public bool isDone;
    [SerializeField]GameObject TS;

    private void Start() {
        pointsAmount = points.Length - 1;
        if (TS == null)
        {
            if (Vector2.Distance(transform.position, TS.transform.position) < 3.5f)
            {
                TS.GetComponent<TestScrpt>().LR = this.GetComponent<LR_Controller>();
            }
            return;
        }
    }
    
    private void Update() {
        if (TS == null)
        {
            if (Vector2.Distance(transform.position, TS.transform.position) < 3.5f)
            {
                TS.GetComponent<TestScrpt>().LR = this.GetComponent<LR_Controller>();
            }
            return;
        }

        if (pipeCon[0].isSnapped)
        {
            OPoint = pipeCon[0].transform;
            CPoint = pipeCon[0].snappableParent.transform;
        }
        else
        {
            OPoint = null;
            CPoint = null;
        }

        if (pipeCon[1].isSnapped)
        {
            OPoint = pipeCon[1].transform;
            CPoint = pipeCon[1].snappableParent.transform;
        }
        else
        {
            OPoint = null;
            CPoint = null;
        }



    }

    private void OnDrawGizmos() {
        pointsAmount = points.Length - 1;


        foreach (Transform gameObjectPoint in points)
        {
            if (points != null)
            {
                foreach (Transform point in points)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawWireSphere(point.position, pointSize);
                }
            
                for (int i = 0; i < pointsAmount; i++)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(points[i].position, points[i + 1].position);
                }

                if(pipeCon[0].isSnapped)
                {
                    if (OPoint != null && CPoint != null)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawLine(OPoint.position, CPoint.position);
                    }
                }

                if(pipeCon[1].isSnapped)
                {
                    if (OPoint != null && CPoint != null)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawLine(OPoint.position, CPoint.position);
                    }
                }
            }
            else
            {
                return;
            }
        }
    }
}
