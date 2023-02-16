using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

//[RequireComponent(typeof(BoxCollider2D))]
public class PipeControllerScript : MonoBehaviour
{
    public bool isSnapped;
    bool once;
    public List<GameObject> snappableParent;
    public int snappableParentNum;
    public Vector2 offSet;
    MovePipe movePipe;
    public Transform parentsTransform;
    Light2D highlight;
    public float lightStrength;

    private void Start() {
        movePipe = GetComponentInParent<MovePipe>();
        highlight = GetComponentInParent<Light2D>();
        
    }
    private void Update() {

        

        if (isSnapped)
        {
            parentsTransform.position = (Vector2)snappableParent[snappableParentNum].transform.position + offSet;
        }
        else
        {
            once = false;
        }

        if (isSnapped && !movePipe.mouseOn && !snappableParent[snappableParentNum].GetComponentInParent<MovePipe>().mouseOn)
        {
            if(!once)
            {
                highlight.intensity = 0.20f;
                highlight.intensity -= Time.deltaTime * lightStrength;
                if (highlight.intensity <= 0)
                {
                    highlight.intensity = 0;
                    once = true;
                }
            }
        }
       

        if (snappableParent.Capacity > 0)
        {
            if (movePipe.mouseOn)
            {
                isSnapped = false;
                snappableParent[snappableParentNum].GetComponent<PipeControllerScript>().isSnapped = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Snappable")
        {
            isSnapped = true;
            if (!snappableParent.Contains(other.gameObject))
            {
                snappableParent.Add(other.gameObject);
            }
            snappableParentNum = snappableParent.IndexOf(other.gameObject);
            offSet = parentsTransform.position - snappableParent[snappableParentNum].transform.position;
        
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Snappable")
        {
            if (!snappableParent[snappableParentNum].GetComponentInParent<MovePipe>().mouseOn)
            {
                isSnapped = true;
            }
        }
    }


}
