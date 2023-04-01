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
    public AudioSource deathSound;
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
    public static bool died;
    SpriteRenderer SR;


    private void Start()
    {
        mouseOn = false;

        #region Components
        boxCollider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();

        #endregion

        isConOneConnected = false;
        isConTwoConnected = false;
        isWireConnected = false;// if 1 port is false the wire is not connected
        
        #region WireComponent???(Rename this section)
        canStretchUp = true;
        canStretchDown = true;
        canRotate = true;
        boxSize.x = transform.localScale.x;
        rotate = transform.rotation.z;
        yScale = transform.localScale.y;
        xScale = transform.localScale.x;
        #endregion

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

            if (wireSelected == true)
            {
                GetComponent<SpriteRenderer>().color = highlightedColor;

            }

            wireSelected = true;
            if (canRotate == true)
            {
                if (Input.GetKey(KeyCode.Q))
                {
                    transform.rotation = Quaternion.Euler(0, 0, rotate);
                    rotate += 0.6f;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    transform.rotation = Quaternion.Euler(0, 0, rotate);
                    rotate -= 0.6f;
                }
            }
        }
    }

    private void OnMouseDrag()
    {
        mouseOn = true;//checks if player is clicking the object

    }
    private void OnMouseDown() {
        canRotate = true;
        ObjectCamPos = Camera.main.WorldToScreenPoint(transform.position);
        CursorControl.SetLocalCursorPos(ObjectCamPos);
    }

    private void OnMouseUp()
    {
        mouseOn = false;//when player clicks off object.
    }

    void OnTriggerEnter2D(Collider2D collision)// when wire collides with object
    {
        if (collision.gameObject.tag == con1Tag)// if its connectorONe
        {
            isConOneConnected = true;// is connected to port

        }
        if (collision.gameObject.tag == con2Tag)
        {
            isConTwoConnected = true;

        }
        if ( isConOneConnected && isConOneConnected == true)// if both ports connection is true
        {
            isWireConnected = true;// wire is connected

        }
        if (collision.gameObject.tag == "wireTwo" || collision.gameObject.tag == "wireThree" || collision.gameObject.tag == "wireFive" || collision.gameObject.tag == "wireOne")// if collides with other wires
        {
            deathSound.Play();

            boxCollider.isTrigger = true;
            StartCoroutine(CCoroutine());
            //       GameManagerScript.LoadWirePuzzle();// reload scene
            //Debug.Log("Collision");// test collision works with log message
            conOne = false;// no longer connected to  port
            conTwo = false;
            wireCon = false;// if 1 port is false the wire is not connected
            
        }

        if (collision.gameObject.tag == "wall")
        {
            StartCoroutine(ColCoroutine());
            boxCollider.isTrigger = false;
            canRotate = false;
            canStretchUp = false;
            canStretchDown = false;
            hitWall = true;

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

    public IEnumerator CCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        
        yield return new WaitForSeconds(0.5f);// wait for a secound and change color
        GameManagerScript.UnloadWirePuzzle();
        
        yield return null;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wires")// if collides with other wires
        {
            deathSound.Play();
            boxCollider.isTrigger = true;
            StartCoroutine(CCoroutine());
            //GameManagerScript.UnloadWirePuzzle();
            //       GameManagerScript.LoadWirePuzzle();// reload scene
            //Debug.Log("Collision");// test collision works with log message
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
        if (collision.gameObject.tag == con1Tag)// if exit port 1 collision box
        {
            isConOneConnected = false;// no longer connected to  port
            isConTwoConnected = false;
            isWireConnected = false;// if 1 port is false the wire is not connected 
            
        }
        if (collision.gameObject.tag == con2Tag)
        {
            isConTwoConnected = false;
            isWireConnected = false;

        }
        if (collision.gameObject.tag == "wall")
        {
            hitWall = false;
            boxCollider.isTrigger = true;
            canRotate = true;
            canStretchUp = true;
            canStretchDown = true;
        }



    }
}
