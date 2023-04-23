using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
public class PipeConnectScript : MonoBehaviour
{
    public bool isSnapped;
    public GameObject snappableParent;
    public Vector2 offSet;
    MovePipe movePipe;
    MovePipe snapObjMovePipe;
    PipeController pipeController;
    public Transform parentsTransform;
    Vector2 outlineVector;

    private void Start() {
        movePipe = GetComponentInParent<MovePipe>();
        pipeController = GetComponentInParent<PipeController>();
    }
    private void Update() {

        if (isSnapped)
        {
            parentsTransform.position = (Vector2)snappableParent.transform.position + offSet;
            pipeController.pipeMaterial.SetVector("_Thickness", outlineVector);
            outlineVector = new Vector2(0.03f, 0);
        }
        else
        {
            pipeController.pipeMaterial.SetVector("_Thickness", outlineVector);
            outlineVector = new Vector2(0, 0);
        }

        if (snappableParent != null)
        {
            if (movePipe != null && snappableParent.GetComponentInParent<MovePipe>() != null)
            {
                if (movePipe.mouseOn || snappableParent.GetComponentInParent<MovePipe>().mouseOn)
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
            }
        }
    }


}
