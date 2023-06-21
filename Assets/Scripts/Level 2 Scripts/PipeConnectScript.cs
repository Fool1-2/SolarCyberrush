using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class PipeConnectScript : MonoBehaviour
{
    public bool isSnapped;
    public bool once;
    public GameObject snappableParent;
    public Vector2 offSet;
    MovePipe movePipe;
    MovePipe snapObjMovePipe;
    public Transform parentsTransform;
    Animation anim;

    private void Start() {
        movePipe = GetComponentInParent<MovePipe>();
        anim = GetComponentInParent<Animation>();
    }
    private void Update() {

        if (isSnapped)
        {
            parentsTransform.position = (Vector2)snappableParent.transform.position + offSet;
        }
        else
        {
            once = false;
        }

        if (snappableParent != null)
        {
            if (isSnapped && snappableParent.GetComponent<PipeConnectScript>().isSnapped)
            {
                if (!once)
                {
                    anim.Play();
                    once = true;
                }
            }

            if (movePipe != null && snappableParent.GetComponentInParent<MovePipe>() != null)
            {
                if (movePipe.mouseOn || snappableParent.GetComponentInParent<MovePipe>().mouseOn)
                {
                    isSnapped = false;
                    snappableParent.GetComponent<PipeConnectScript>().isSnapped = false;
                }
            }

            if (movePipe != null && snappableParent.GetComponentInParent<MovePipe>() != null)
            {
                if (movePipe.clicked || snappableParent.GetComponentInParent<MovePipe>().clicked)
                {
                    isSnapped = false;
                    snappableParent.GetComponent<PipeConnectScript>().isSnapped = false;
                }
            }
            

            if (movePipe != null && snappableParent.GetComponentInParent<MovePipe>() == null)
            {
                if (movePipe.mouseOn)
                {
                    isSnapped = false;
                    snappableParent.GetComponent<PipeConnectScript>().isSnapped = false;
                }

                if (movePipe.clicked)
                {
                    isSnapped = false;
                    snappableParent.GetComponent<PipeConnectScript>().isSnapped = false;
                }
            }
            
        }
        else
        {
            return;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Snappable")
        {
            if (movePipe != null)
            {
                #region Mouse Version
                if (!movePipe.mouseOn)
                {
                    snappableParent = other.gameObject;
                    if (snappableParent != null && snappableParent.GetComponentInParent<MovePipe>() != null)
                    {
                        if (!movePipe.mouseOn && !snappableParent.GetComponentInParent<MovePipe>().mouseOn)
                        {
                            isSnapped = true;
                            offSet = parentsTransform.position - snappableParent.transform.position;
                        }
                    }
                    else
                    {
                        return;
                    }

                    if (snappableParent != null && snappableParent.GetComponentInParent<MovePipe>() == null)
                    {
                        if (!movePipe.mouseOn)
                        {
                            isSnapped = true;
                            offSet = parentsTransform.position - snappableParent.transform.position;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                #endregion
                
                #region Virtual Mouse Version
                if (!movePipe.clicked)
                {
                    snappableParent = other.gameObject;
                    if (snappableParent != null && snappableParent.GetComponentInParent<MovePipe>() != null)
                    {
                        if (!movePipe.clicked && !snappableParent.GetComponentInParent<MovePipe>().clicked)
                        {
                            isSnapped = true;
                            offSet = parentsTransform.position - snappableParent.transform.position;
                        }
                    }
                    else
                    {
                        return;
                    }

                    if (snappableParent != null && snappableParent.GetComponentInParent<MovePipe>() == null)
                    {
                        if (!movePipe.clicked)
                        {
                            isSnapped = true;
                            offSet = parentsTransform.position - snappableParent.transform.position;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                #endregion
            }
            else
            {
                snappableParent = other.gameObject;
                if (!snappableParent.GetComponentInParent<MovePipe>().mouseOn)
                {
                    if (snappableParent != null)
                    {
                        if (!snappableParent.GetComponentInParent<MovePipe>().mouseOn)
                        {
                            isSnapped = true;
                            offSet = parentsTransform.position - snappableParent.transform.position;
                        }
                    }
                }

                #region Virtual Mouse Version
                if (!snappableParent.GetComponentInParent<MovePipe>().clicked)
                {
                    if (snappableParent != null)
                    {
                        if (!snappableParent.GetComponentInParent<MovePipe>().clicked)
                        {
                            isSnapped = true;
                            offSet = parentsTransform.position - snappableParent.transform.position;
                        }
                    }
                }
                #endregion
            }
        }
    }


}