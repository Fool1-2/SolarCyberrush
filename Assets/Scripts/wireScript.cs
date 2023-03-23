using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]//adds rigidbody2D
[RequireComponent(typeof(BoxCollider2D))]//adds boxcollider2D
public class wireScript : MonoBehaviour
{
    //Turn the positon of in constraints in rigidbody to limit the axis its on
    // pro dev note comments may be outdated


    [SerializeField] bool mouseOn;
    [SerializeField] Rigidbody2D rb;
    Vector2 mousePos;
    public Vector2 boxSize;
    public Transform StartObject;
    public Transform EndObject;
    HingeJoint2D hingeJoint2D;
    Collider2D boxCollider;
    Rotat rotat;// rotate script is rotate
    public static bool conOne;// connector one
    public static bool conTwo;// connector two
    public static bool wireCon;// is wire connected
    public bool wireSelected;
    public float yScale;
    public float xScale;
    public float rotate;
    public bool canRotate;
    public bool canStretchUp;
    public bool hitWall;
    public bool canStretchDown;
    SpriteRenderer SR;


    private void Start()
    {
        mouseOn = false;
        boxSize = transform.localScale;
        hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
        boxCollider = GetComponent<Collider2D>();
        rotat = gameObject.GetComponent<Rotat>();
        // Debug.Log("Hello world");
        conOne = false;// wire is not connected to port
        conTwo = false;// wire is not connected to port
        wireCon = false;// if 1 port is false the wire is not connected
        boxSize.x = 5.338786f;
        canStretchUp = true;
        rotate = -89.549f;
        canStretchDown = true;
        canRotate = true;
        yScale = transform.localScale.y;
        xScale = transform.localScale.x;

    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Gets the camera position from the screen and puts into the world.

        if (!mouseOn)//If the mouse is off turn the movement off.
        {
            wireSelected = false;
            if (wireSelected == false)
            {


                GetComponent<SpriteRenderer>().color = Color.white;

            }
        }

        if (mouseOn)//if mouse is on the object move the object according to the position of the mouse. 
        {
            // float distance = Vector2.Distance(boxSize, mousePos);
            rb.MovePosition(new Vector2(mousePos.x, mousePos.y));
            //transform.position = new Vector2(mousePos.x, mousePos.y);


            if (yScale >= 10)
            {
                canStretchUp = false;


            }
            if (yScale < 5 || hitWall == true)
            {
                canStretchDown = false;


            }
            if (yScale < 10 && hitWall == false)
            {
                canStretchUp = true;


            }
            if (yScale >= 5 && hitWall == false)
            {
                canStretchDown = true;


            }
           /* if(hitWall == true)
            {
                canStretchDown = false;
                canStretchUp = false;
            }
            if (hitWall == false)
            {
                canStretchDown = true;
                canStretchUp = true;
            }*/

            

            if (canStretchUp == true)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    //float distance = Vector2.Distance(boxSize, mousePos);
                    transform.localScale = new Vector2(xScale, yScale);
                    yScale += 0.01f;

                }
            }
            if (canStretchDown == true)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    //float distance = Vector2.Distance(boxSize, mousePos);
                    transform.localScale = new Vector2(xScale, yScale);
                    yScale -= 0.01f;
                }


            }




            if (Input.GetKeyDown(KeyCode.R))
            {
                //checks if the script is enabled or disabled
                rotat.enabled = !rotat.enabled;

            }
            if (wireSelected == true)
            {


                GetComponent<SpriteRenderer>().color = Color.yellow;

            }

            wireSelected = true;
            if (canRotate == true)
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    //float rotate_Z = Mathf.Atan2(mouse_Pos.y, mouse_Pos.x) * Mathf.Rad2Deg;
                    // rotate_Z -= 90;
                    transform.rotation = Quaternion.Euler(0, 0, rotate);
                    rotate += 0.6f;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    //float rotate_Z = Mathf.Atan2(mouse_Pos.y, mouse_Pos.x) * Mathf.Rad2Deg;
                    // rotate_Z -= 90;
                    transform.rotation = Quaternion.Euler(0, 0, rotate);
                    rotate -= 0.6f;
                }
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
        if (collision.gameObject.tag == "ConnecterOne")// if its connectorONe
        {
            Debug.Log("Connecting 1");// say connecting(this is more for the devs)
            conOne = true;// is connected to port
        }
        if (collision.gameObject.tag == "ConnectorTwo")
        {
            Debug.Log("Connecting 2");
            conTwo = true;
        }
        if ( conOne && conTwo == true)// if both ports connection is true
        {
            wireCon = true;// wire is connected
            Debug.Log("Wire Connected");
        }
        if (collision.gameObject.tag == "wireTwo" || collision.gameObject.tag == "wireThree" || collision.gameObject.tag == "wireFive" || collision.gameObject.tag == "wireOne")// if collides with other wires
        {
            boxCollider.isTrigger = true;
            GameManagerScript.UnloadWirePuzzle();
            //       GameManagerScript.LoadWirePuzzle();// reload scene
            Debug.Log("Collision");// test collision works with log message
            conOne = false;// no longer connected to  port
            conTwo = false;
            wireCon = false;// if 1 port is false the wire is not connected 
        }

        if (collision.gameObject.tag == "wall")
        {
            StartCoroutine(ColCoroutine());
            boxCollider.isTrigger = false;
            Debug.Log("Collision");
            canRotate = false;
           // rotate = 0;
            canStretchUp = false;
            canStretchDown = false;
            hitWall = true;
            //transform.rotation = Quaternion.Euler(0, 0, 0);

        }


    }
    IEnumerator ColCoroutine()
    {

        if (boxCollider.isTrigger == false)
        {
            yield return new WaitForSeconds(1);
            boxCollider.isTrigger = true;

            yield return null;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wireTwo" || collision.gameObject.tag == "wireThree" || collision.gameObject.tag == "wireFive" || collision.gameObject.tag == "wireOne")// if collides with other wires
        {
            boxCollider.isTrigger = true;
            GameManagerScript.UnloadWirePuzzle();
     //       GameManagerScript.LoadWirePuzzle();// reload scene
            Debug.Log("Collision");// test collision works with log message
            conOne = false;// no longer connected to  port
            conTwo = false;
            wireCon = false;// if 1 port is false the wire is not connected 
        }
        if (collision.gameObject.tag == "wall")
        {
            canRotate = false;
            canStretchUp = false;
            canStretchDown = false;
            hitWall = true;


        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "wall")
        {
            canRotate = true;
            canStretchUp = true;
            canStretchDown = true;
            hitWall = false;


        }

    }
    void OnTriggerExit2D(Collider2D collision)// when wire exits collision box
    {
        if (collision.gameObject.tag == "ConnecterOne")// if exit port 1 collision box
        {
            Debug.Log("Disconnecting 1");// print disconnect message
            conOne = false;// no longer connected to  port
            conTwo = false;
            wireCon = false;// if 1 port is false the wire is not connected 
            Debug.Log("Wire Disconnected");
        }
        if (collision.gameObject.tag == "ConnectorTwo")
        {
            Debug.Log("Disconnecting 2");
            conTwo = false;
            wireCon = false;
            Debug.Log("Wire Disconnected");
        }
        if (collision.gameObject.tag == "wall")
        {
            hitWall = false;
            boxCollider.isTrigger = true;
            Debug.Log("Collision");
            canRotate = true;
            canStretchUp = true;
            canStretchDown = true;
        }



    }
}
