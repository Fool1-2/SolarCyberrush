using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]//adds rigidbody2D
[RequireComponent(typeof(BoxCollider2D))]//adds boxcollider2D
public class wireThreeScript : MonoBehaviour
{
    //Turn the positon of in constraints in rigidbody to limit the axis its on

    [SerializeField] bool mouseOn;
    [SerializeField] Rigidbody2D rb;
    Vector2 mousePos;
    public Vector2 boxSize;
    public Transform StartObject;
    public Transform EndObject;
    HingeJoint2D hingeJoint2D;
    Rotat rotat;
    public static bool conFive;
    public static bool conSix;
    public static bool wireCon;
    



    private void Start()
    {
        mouseOn = false;
        boxSize = transform.localScale;
        rotat = gameObject.GetComponent<Rotat>();
        // Debug.Log("Hello world");
        conFive = false;
        conSix = false;
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Gets the camera position from the screen and puts into the world.

        if (!mouseOn)//If the mouse is off turn the movement off.
        {
            rb.velocity = Vector2.zero;
        }



    }

    private void FixedUpdate()
    {

        if (mouseOn)//if mouse is on the object move the object according to the position of the mouse. 
        {
            // float distance = Vector2.Distance(boxSize, mousePos);
            rb.MovePosition(new Vector2(mousePos.x, mousePos.y));
            //   transform.localScale = new Vector2(distance,boxSize.y);
            if (Input.GetKey(KeyCode.Space))
            {
                //float distance = Vector2.Distance(boxSize, mousePos);
                transform.localScale = new Vector2(mousePos.x, boxSize.y);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                //checks if the script is enabled or disabled
                rotat.enabled = !rotat.enabled;

            }



        }
    }

    private void OnMouseDrag()
    {
        mouseOn = true;//checks if player is clicking the object

    }

    private void OnMouseUp()
    {
        mouseOn = false;//when player clicks off object.
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ConnectorFive")
        {
            Debug.Log("Connecting 5");
            conFive = true;
        }
        if (collision.gameObject.tag == "ConnectorSix")
        {
            Debug.Log("Connecting 6");
            conSix = true;
        }
        if (conFive && conSix == true)
        {
            wireCon = true;
            Debug.Log("Wire3 Connected");
        }
        if (collision.gameObject.tag == "wireTwo" || collision.gameObject.tag == "wire")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Collision");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ConnectorFive")
        {
            Debug.Log("Disconnecting 5");
            conFive = false;
        }
        if (collision.gameObject.tag == "ConnectorFour")
        {
            Debug.Log("Disconnecting 6");
            conSix = false;
        }
        if (conFive && conSix == false)
        {
            wireCon = false;
            Debug.Log("Wire3 Disconnected");
        }
    }

}
