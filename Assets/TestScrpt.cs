using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScrpt : MonoBehaviour
{
    public LR_Controller LR;
    public Transform curPos;
    public float speed;
    public bool startFromLast;
    public bool isColliding;

    void findCurPos()
    {
        if (curPos == null)
        {
            foreach (Transform point in LR.points)
            {
                if (Vector2.Distance(point.position, this.transform.position) < 2)
                {
                    curPos = point;
                }
            }
        }
    }

    private void Start() {
        findCurPos();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print("Why n work??");
        if(isColliding) return;
        isColliding = true;

        if (isColliding)
        {
            if (curPos == LR.points[0])
            {
                startFromLast = false;
            }
        
            if (curPos == LR.points[LR.pointsAmount])
            {
                startFromLast = true;
            }
        }
    }

    private void Update() {


        if (LR != null)
        {
            if (curPos != null)
            {
    
                transform.position = Vector3.MoveTowards(transform.position, curPos.position, speed * Time.deltaTime);
        
                if (Vector2.Distance(this.transform.position, curPos.position) < 0.3f)
                {
    
                    if (!startFromLast)
                    {
                        for (int i = 0; i < LR.pointsAmount; i++)
                        {
                            if (curPos == LR.points[i])
                            {
                                curPos = LR.points[i + 1];
                                break;
                            }
                        }
                    }
    
                    if (startFromLast)
                    {
                        for (int i = LR.pointsAmount; i > 0; i--)
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
    
            if (LR.pipeCon[0].isSnapped)
            {
                if (!LR.isDone)
                {
                    if (Vector2.Distance(this.transform.position, LR.OPoint.position) < 2f)
                    {
                        //print("true");
                        curPos = LR.CPoint;
                    }
                }

                if (this.transform.position == LR.CPoint.transform.position)
                {
                    LR.isDone = true;
                    LR = LR.CPoint.GetComponentInParent<LR_Controller>();
                }
            }

            if (LR.pipeCon[1].isSnapped)
            {
                if (!LR.isDone)
                {
                    if (Vector2.Distance(this.transform.position, LR.OPoint.position) < 2f)
                    {
                        //print("true");
                        curPos = LR.CPoint;
                    }
                }

                if (this.transform.position == LR.CPoint.transform.position)
                {
                    LR.isDone = true;
                    LR = LR.CPoint.GetComponentInParent<LR_Controller>();
                }
            }
        }
        else
        {
            return;
        }
    }
    

}
