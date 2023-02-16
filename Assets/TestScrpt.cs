using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScrpt : MonoBehaviour
{
    public LR_Controller LR;
    public Transform curPos;
    public float speed;
    public bool startFromLast;


    void findCurPos()
    {
        if (curPos == null)
        {
            foreach (Transform point in LR.points)
            {
                if (Vector2.Distance(point.position, this.transform.position) < 2)
                {
                    print(point);
                    curPos = point;
                }
            }
        }
    }

    private void Start() {
        findCurPos();
        //LR.GetNextPoint(curPos, this.transform);
    }

    private void Update() {

        if (curPos != null)
        {

            transform.position = Vector3.MoveTowards(transform.position, curPos.position, speed * Time.deltaTime);
    
            if (Vector2.Distance(this.transform.position, curPos.position) < 0.3f)
            {
                if (curPos == LR.points[0])
                {
                    startFromLast = false;
                }

                if (curPos = LR.points[LR.points.Length - 1])
                {
                    startFromLast = true;
                }

                if (!startFromLast)
                {
                    for (int i = 0; i < LR.points.Length - 1; i++)
                    {
                        print("working");
                        if (curPos == LR.points[i])
                        {
                            curPos = LR.points[i + 1];
                            break;
                        }
                    }
                }

                if (startFromLast)
                {
                    for (int i = LR.points.Length - 1; i > 0; i--)
                    {
                        if (curPos == LR.points[i])
                        {
                            curPos = LR.points[i - 1];
                            break;
                        }
                    }
                }
            }
        }

        if (LR.iscon)
        {
            if (Vector2.Distance(this.transform.position, LR.OPoint.position) < 2f)
            {
                print("true");
                curPos = LR.CPoint;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        LR = other.gameObject.GetComponent<LR_Controller>();
    }

}
