using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isColliding) return;
        isColliding = true;

        if (isColliding)
        {
            if (Vector2.Distance(curPos.position, LR.points[0].position) < 0.2f)
            {
                startFromLast = false;
            }

            if (Vector2.Distance(curPos.position, LR.points[LR.points.Length - 1].position) < 0.2f)
            {
                startFromLast = true;
            }
        }

        if (collision.gameObject.tag == "WinObj")
        {
            //collision.GetComponent<SwichScenes>().SceneSwitch("L1F2");
        }
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.P))
        {
            GrateScript.slidePuzzleCompleted = true;
            SGameManager.isWin = true;
        }

        if (LR != null)
        {
            if (LR.pipeCon[0].isSnapped)
            {
                if (LR.isDone)
                {
                    curPos = LR.CPoint;
                    if (curPos == LR.CPoint)
                    {
                        isColliding = false;
                    }
                    LR = LR.CPoint.GetComponentInParent<LR_Controller>();
                }
            }

            if (LR.pipeCon[1].isSnapped)
            {
                if (LR.isDone)
                {
                    curPos = LR.CPoint;
                    if (curPos == LR.CPoint)
                    {
                        isColliding = false;
                    }
                    LR = LR.CPoint.GetComponentInParent<LR_Controller>();
                }
            }

            if (!LR.isDone)
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

                            if (this.transform.position == LR.points[LR.pointsAmount].position)
                            {
                                LR.isDone = true;
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

                            if (this.transform.position == LR.points[0].position)
                            {
                                LR.isDone = true;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            return;
        }

        if (LR.isDone)
        {
            if (LR.OPoint == null && LR.CPoint == null)
            {
                print("working??");
                Destroy(this.gameObject);
            }

            if (curPos == null)
            {
                print("working??");
                Destroy(this.gameObject);
            }
        }
    }


}
