using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]//adds rigidbody2D
[RequireComponent(typeof(BoxCollider2D))]//adds boxcollider2D
public class wireFourScript : MonoBehaviour
{
    //Turn the positon of in constraints in rigidbody to limit the axis its on

    [SerializeField] bool mouseOn;
    [SerializeField] Rigidbody2D rb;
    Vector2 mousePos;
    public Vector2 boxSize;
    public Transform StartObject;
    public Transform EndObject;
    HingeJoint2D hingeJoint2D;
    Collider2D boxCollider;
    Rotat rotat;// rotate script is rotate
    public static bool conSev;// connector one
    public static bool conEig;// connector two
    public static bool wireCon;// is wire connected



    private void Start()
    {
        mouseOn = false;
      
        boxSize = transform.localScale;
        hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
        boxCollider = GetComponent<Collider2D>();
        rotat = gameObject.GetComponent<Rotat>();
        // Debug.Log("Hello world");
        conSev = false;// wire is not connected to port
        conEig = false;// wire is not connected to port

    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Gets the camera position from the screen and puts into the world.

        if (!mouseOn)//If the mouse is off turn the movement off.
        {
            rb.velocity = Vector2.zero;
        }

        if (mouseOn)//if mouse is on the object move the object according to the position of the mouse. 
        {
            // float distance = Vector2.Distance(boxSize, mousePos);
            rb.MovePosition(new Vector2(mousePos.x, mousePos.y));
            //   transform.localScale = new Vector2(distance,boxSize.y);
            if (Input.GetKey(KeyCode.Space))
            {
                //float distance = Vector2.Distance(boxSize, mousePos);
                transform.localScale = new Vector2(boxSize.x, mousePos.y);

            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                //checks if the script is enabled or disabled
                
                rotat.enabled = !rotat.enabled;

            }



        }

    }

    private void FixedUpdate()
    {


    }

    private void OnMouseDrag()
    {
        mouseOn = true;//checks if player is clicking the object

    }

    private void OnMouseUp()
    {
        mouseOn = false;//when player clicks off object.
    }

    void OnTriggerEnter2D(Collider2D collision)// when wire collides with object
    {
        if (collision.gameObject.tag == "ConnectorSeven")// if its connectorONe
        {
            Debug.Log("Connecting 7");// say connecting(this is more for the devs)
            conSev = true;// is connected to port
            boxCollider.isTrigger = true;
        }
        if (collision.gameObject.tag == "ConnectorEight")
        {
            Debug.Log("Connecting 8");
            conEig = true;
            boxCollider.isTrigger = true;
        }
        if (conSev && conEig == true)// if both ports connection is true
        {
            wireCon = true;// wire is connected
            Debug.Log("Wire Connected");
        }
        if (collision.gameObject.tag == "wireTwo" || collision.gameObject.tag == "wireThree" || collision.gameObject.tag == "wireFive" || collision.gameObject.tag == "wireOne")// if collides with other wires
        {
            boxCollider.isTrigger = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// reload scene
            Debug.Log("Collision");// test collision works with log message
        }

        if (collision.gameObject.tag == "wall")
        {
            StartCoroutine(ColCoroutine());
            boxCollider.isTrigger = false;
            Debug.Log("Collision");
            
        }

    }
    IEnumerator ColCoroutine()
    {

        
        yield return new WaitForSeconds(1); 
        boxCollider.isTrigger = true;

        yield return null;
    }

    // 
    void OnTriggerExit2D(Collider2D collision)// when wire exits collision box
    {
        if (collision.gameObject.tag == "ConnectorSeven")// if exit port 1 collision box
        {
            Debug.Log("Disconnecting 7");// print disconnect message
            conSev = false;// no longer connected to  port
            conEig = false;
            wireCon = false;// if 1 port is false the wire is not connected 
            Debug.Log("Wire Disconnected");
        }
        if (collision.gameObject.tag == "ConnectorEight")
        {
            Debug.Log("Disconnecting 8");
            conEig = false;
            wireCon = false;
            Debug.Log("Wire Disconnected");
        }
        if (collision.gameObject.tag == "wall")
        {
            boxCollider.isTrigger = true;
            Debug.Log("HINEn");
        }



    }

}
