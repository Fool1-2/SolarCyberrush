using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player; // get object(player)
    public Camera cam;
    public bool onBorder;
    //public Transform Border; // get empty object(border)
    public float[] borderVar;
    public float borderPosition;
    public Transform camTransform;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        onBorder = false;// determines if camera is on empty game object border
        camTransform = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x <= borderVar[0])// if player x position is less than -20 set camera to border
        {
            //gameObject.transform.position.x = -20;
            
            onBorder = true;
            //camTransform.position.x = borderVar[0];
        }
        if (player.position.x >= borderVar[1])// if player x position is greater than -30 set camera back to player
        {
            onBorder = false;
        }
        if (player.position.y <= borderVar[2])



        if (onBorder == false)
        { 
        transform.position = new Vector3(player.position.x, player.position.y, -10); // get player position.x and update on that position
        }
        if (onBorder == true)
        {
            transform.position = new Vector3(borderPosition, 0, -10); // get player position.x and update on that position
        }


    }
  /*  public void OnTriggerEnter2D(Collider2D col)
    {
        if (GetComponent<Collider>().gameObject.tag == "Border")
        {
            onBorder = true;
            Debug.Log("TAG");
        }

    }*/
}
