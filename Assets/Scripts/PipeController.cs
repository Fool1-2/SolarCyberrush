using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public Transform[] points;
    public PipeConnectScript[] pipeCon;
    public Transform OPoint;
    public Transform CPoint;
    public List<PipeController> lr;
    public int pointsAmount;
    public float pointSize;
    public bool iscon;
    public bool isDone;
    bool isColliding;
    [SerializeField]GameObject TS;

    private void Start() {
        pointsAmount = points.Length - 1;
        
    }

    private void Update() {

        if (TS != null)
        {
            if (TS.GetComponent<PlayerPipePuzzle>().LR == this.GetComponent<PipeController>())
            {
                if (pipeCon[0].isSnapped)
                {
                    if (!pipeCon[0].snappableParent.GetComponentInParent<PipeController>().isDone)
                    {
                        OPoint = pipeCon[0].transform;
                        CPoint = pipeCon[0].snappableParent.transform;
                    }
                }

                if (pipeCon[1].isSnapped)
                {
                    if (!pipeCon[1].snappableParent.GetComponentInParent<PipeController>().isDone)
                    {
                        OPoint = pipeCon[1].transform;
                        CPoint = pipeCon[1].snappableParent.transform;
                    }
                }
            }
        }
        else
        {
            return;
        }

        if (!pipeCon[1].isSnapped && !pipeCon[0].isSnapped)
        {
            OPoint = null;
            CPoint = null;
        }

        if (!isDone)
        {
            if (OPoint != null)
            {
                if (TS.transform.position == OPoint.position)
                {
                    isDone = true;
                }
            }
        }


    }

    private void OnDrawGizmos() {
        pointsAmount = points.Length - 1;


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

            if (pipeCon[0].isSnapped)
            {
                Gizmos.color = Color.red;
                if (OPoint != null && CPoint != null)
                {
                    Gizmos.DrawLine(OPoint.position, CPoint.position);
                }
            }
            

            if (pipeCon[1].isSnapped)
            {
                Gizmos.color = Color.red;
                if (OPoint != null && CPoint != null)
                {
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
