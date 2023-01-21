using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]//adds rigidbody2D
[RequireComponent(typeof(BoxCollider2D))]//adds boxcollider2D
public class wireScript : MonoBehaviour
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
    public static bool conOne;
    public static bool conTwo;
    public static bool wireCon;



    private void Start()
    {
        mouseOn = false;
        boxSize = transform.localScale;
        hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
        rotat = gameObject.GetComponent<Rotat>();
        // Debug.Log("Hello world");
        conOne = false;
        conTwo = false;
       
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
        if (collision.gameObject.tag == "ConnecterOne")
        {
            Debug.Log("Connecting 1");
            conOne = true;
        }
        if (collision.gameObject.tag == "ConnectorTwo")
        {
            Debug.Log("Connecting 2");
            conTwo = true;
        }
        if ( conOne && conTwo == true)
        {
            wireCon = true;
            Debug.Log("Wire Connected");
        }
        if (collision.gameObject.tag == "wireTwo" || collision.gameObject.tag == "wireThree")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Collision");
        }
    }

   // 
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ConnecterOne")
        {
            Debug.Log("Disconnecting 1");
            conOne = false;
        }
        if (collision.gameObject.tag == "ConnectorTwo")
        {
            Debug.Log("Disconnecting 2");
            conTwo = false;
        }
        if (conOne && conTwo == false)
        {
            wireCon = false;
            Debug.Log("Wire Disconnected");
        }


    }
}
