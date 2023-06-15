using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]//adds rigidbody2D
[RequireComponent(typeof(BoxCollider2D))]//adds boxcollider2D
public class wireFourScript : MonoBehaviour
{
    //Turn the positon of in constraints in rigidbody to limit the axis its on

    [SerializeField]MovePipe moveWires;
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
    public bool wireSelected;
    public float yScale;
    public float rotate;
    public bool canRotate;
    public bool canStretchUp;
    public bool canStretchDown;
    public bool hitWall;
    public float xScale;
    public AudioSource deathSound;
    SpriteRenderer SR;
    public Vector2 ObjectCamPos;


    private void Start()
    {
        moveWires = GetComponent<MovePipe>();
        boxSize = transform.localScale;
        hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
        boxCollider = GetComponent<Collider2D>();
        rotat = gameObject.GetComponent<Rotat>();
        // Debug.Log("Hello world");
        conSev = false;// wire is not connected to port
        conEig = false;// wire is not connected to port
        wireCon = false;// if 1 port is false the wire is not connected 
        wireSelected = false;
        gameObject.GetComponent<SpriteRenderer>();
        //boxSize.x = 5.338786f;
        canStretchUp = true;
        canStretchDown = true;
        canRotate = true;
        rotate = -147.912f;
        yScale = transform.localScale.y;
        xScale = transform.localScale.x;


    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Gets the camera position from the screen and puts into the world.
        deathSound.volume = GameManagerScript.volume;
        if (!moveWires.mouseOn)//If the mouse is off turn the movement off.
        {
            rb.velocity = Vector2.zero;
            wireSelected = false;
            if (wireSelected == false)
            {


                GetComponent<SpriteRenderer>().color = Color.white;

            }
        }

        if (moveWires.mouseOn)//if mouse is on the object move the object according to the position of the mouse. 
        {
            // float distance = Vector2.Distance(boxSize, mousePos);
            //rb.MovePosition(new Vector2(mousePos.x, mousePos.y));
            //   transform.localScale = new Vector2(distance,boxSize.y);
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
                    rotate += 0.9f;
                }
                if (Input.GetKey(KeyCode.E))
                {
                    //float rotate_Z = Mathf.Atan2(mouse_Pos.y, mouse_Pos.x) * Mathf.Rad2Deg;
                    // rotate_Z -= 90;
                    transform.rotation = Quaternion.Euler(0, 0, rotate);
                    rotate -= 0.9f;
                }
            }
        }

    }

    private void FixedUpdate()
    {


    }

    void OnTriggerEnter2D(Collider2D collision)// when wire collides with object
    {
        if (collision.gameObject.tag == "ConnectorSeven")// if its connectorONe
        {
            //Debug.Log("Connecting 7");// say connecting(this is more for the devs)
            conSev = true;// is connected to port
            boxCollider.isTrigger = true;
        }
        if (collision.gameObject.tag == "ConnectorEight")
        {
            //Debug.Log("Connecting 8");
            conEig = true;
            boxCollider.isTrigger = true;
        }
        if (conSev && conEig == true)// if both ports connection is true
        {
            wireCon = true;// wire is connected
            //Debug.Log("Wire Connected");
        }
        if (collision.gameObject.tag == "wireTwo" || collision.gameObject.tag == "wireThree" || collision.gameObject.tag == "wireFive" || collision.gameObject.tag == "wireOne")// if collides with other wires
        {
            boxCollider.isTrigger = true;
            StartCoroutine(CCoroutine());
            // GameManagerScript.UnloadWirePuzzle();
            // GameManagerScript.LoadWirePuzzle();// reload scene// reload scene
            //Debug.Log("Collision");// test collision works with log message
            conSev = false;// no longer connected to  port
            conEig = false;
            wireCon = false;// if 1 port is false the wire is not connected

        }

        if (collision.gameObject.tag == "wall")
        {
            StartCoroutine(ColCoroutine());
            boxCollider.isTrigger = false;
            //Debug.Log("Collision");
            canRotate = false;
            // rotate = 0;
            canStretchUp = false;
            canStretchDown = false;
            hitWall = true;
            //transform.rotation = Quaternion.Euler(0, 0, 0);

        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wireTwo" || collision.gameObject.tag == "wireThree" || collision.gameObject.tag == "wireFive" || collision.gameObject.tag == "wireOne")// if collides with other wires
        {
            boxCollider.isTrigger = true;
            StartCoroutine(CCoroutine());
            //GameManagerScript.UnloadWirePuzzle();
            // GameManagerScript.LoadWirePuzzle();// reload scene// reload scene
            //Debug.Log("Collision");// test collision works with log message
            conSev = false;// no longer connected to  port
            conEig = false;
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
    IEnumerator ColCoroutine()
    {

        if (boxCollider.isTrigger == false)
        {
            yield return new WaitForSeconds(2);
            boxCollider.isTrigger = true;
            //Debug.Log("HEHEHE");

            yield return null;
        }

    }
    public IEnumerator CCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        deathSound.Play();
        yield return new WaitForSeconds(0.5f);// wait for a secound and change color
        PlayerAnim.playerFall = true;
        GameManagerScript.UnloadWirePuzzle();

        yield return null;
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
    // 
    void OnTriggerExit2D(Collider2D collision)// when wire exits collision box
    {
        if (collision.gameObject.tag == "ConnectorSeven")// if exit port 1 collision box
        {
            //Debug.Log("Disconnecting 7");// print disconnect message
            conSev = false;// no longer connected to  port
            conEig = false;
            wireCon = false;// if 1 port is false the wire is not connected 
            //Debug.Log("Wire Disconnected");
        }
        if (collision.gameObject.tag == "ConnectorEight")
        {
            //Debug.Log("Disconnecting 8");
            conEig = false;
            wireCon = false;
            //Debug.Log("Wire Disconnected");
        }
        if (collision.gameObject.tag == "wall")
        {
            hitWall = false;
            boxCollider.isTrigger = true;
            //Debug.Log("Collision");
            canRotate = true;
            canStretchUp = true;
            canStretchDown = true;
        }



    }

}
