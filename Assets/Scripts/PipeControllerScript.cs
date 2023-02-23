using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

//[RequireComponent(typeof(BoxCollider2D))]
public class PipeControllerScript : MonoBehaviour
{
    public bool isSnapped;
    public bool once;
    public GameObject snappableParent;
    public Vector2 offSet;
    MovePipe movePipe;
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

        if (isSnapped && !movePipe.mouseOn && !snappableParent.GetComponentInParent<MovePipe>().mouseOn)
        {
            if (!once)
            {
                anim.Play();
                once = true;
            }
        }
       

        if (movePipe.mouseOn)
        {
            isSnapped = false;
            snappableParent.GetComponent<PipeControllerScript>().isSnapped = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Snappable")
        {
            isSnapped = true;
            snappableParent = other.gameObject;
            offSet = parentsTransform.position - snappableParent.transform.position;
        
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Snappable")
        {
            if (!snappableParent.GetComponentInParent<MovePipe>().mouseOn)
            {
                isSnapped = true;
            }
        }
    }


}
