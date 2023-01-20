using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player; // get object(player)
    public Camera cam;
    public bool onBorder;
    public Transform Border; // get empty object(border)
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        onBorder = false;// determines if camera is on empty game object border
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x <= -20)// if player x position is less than -20 set camera to border
        {
            onBorder = true;
        }
        if (player.position.x >= -30)// if player x position is greater than -30 set camera back to player
        {
            onBorder = false;
        }



        if (onBorder == false)
        { 
        transform.position = new Vector3(player.position.x, player.position.y, -10); // get player position.x and update on that position
        }
        if (onBorder == true)
        {
            transform.position = new Vector3(Border.position.x, 0, -10); // get player position.x and update on that position
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
