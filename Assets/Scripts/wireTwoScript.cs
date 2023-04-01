using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]//adds rigidbody2D
[RequireComponent(typeof(BoxCollider2D))]//adds boxcollider2D
public class wireTwoScript : MonoBehaviour
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
    Collider2D boxCollider;
    public static bool conThree;
    public static bool conFour;
    public static bool wireCon;
    public bool wireSelected;
    public float yScale;
    public float xScale;
    public float rotate;
    public bool canRotate;
    public bool canStretchUp;
    public bool canStretchDown;
    public bool hitWall;
    SpriteRenderer SR;
    public AudioSource deathSound;



    private void Start()
    {
        mouseOn = false;
        boxSize = transform.localScale;
        hingeJoint2D = gameObject.GetComponent<HingeJoint2D>();
        rotat = gameObject.GetComponent<Rotat>();
        boxCollider = GetComponent<Collider2D>();
        // Debug.Log("Hello world");
        conThree = false;
        conFour = false;
        wireCon = false;// if 1 port is false the wire is not connected
        boxSize.x = 7.46202f;
        canStretchUp = true;
        canStretchDown = true;
        canRotate = true;
        rotate = 47.7097015f;
        yScale = transform.localScale.y;
        xScale = transform.localScale.x;
    }

    public void LoadGame()
    {

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ConnectorThree")
        {
            //Debug.Log("Connecting 3");
            conThree = true;
        }
        if (collision.gameObject.tag == "ConnectorFour")
        {
            //Debug.Log("Connecting 4");
            conFour = true;
        }
        if (conThree && conFour == true)
        {
            wireCon = true;
            //Debug.Log("Wire2 Connected");
        }

        if (collision.gameObject.tag == "wall")
        {
            StartCoroutine(ColCoroutine());
            boxCollider.isTrigger = false;
        //    Debug.Log("Collision");
            canRotate = false;
            // rotate = 0;
            canStretchUp = false;
            canStretchDown = false;
            hitWall = true;
            //transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        if (collision.gameObject.tag == "wireTwo" || collision.gameObject.tag == "wireThree" || collision.gameObject.tag == "wireFive" || collision.gameObject.tag == "wireOne" || collision.gameObject.tag == "wireFour")// if collides with other wires
        {
            deathSound.Play();
            boxCollider.isTrigger = true;
           // GameManagerScript.UnloadWirePuzzle();
        //    GameManagerScript.LoadWirePuzzle();
        //    Debug.Log("Collision");// test collision works with log message
            conThree = false;
            conFour = false;
            wireCon = false;
            StartCoroutine(CCoroutine());
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
        if (collision.gameObject.tag == "wireTwo" || collision.gameObject.tag == "wireThree" || collision.gameObject.tag == "wireFive" || collision.gameObject.tag == "wireOne" || collision.gameObject.tag == "wireFour")// if collides with other wires
        {
            deathSound.Play();
            boxCollider.isTrigger = true;
            StartCoroutine(CCoroutine());
            // GameManagerScript.UnloadWirePuzzle();
            //  GameManagerScript.LoadWirePuzzle();
            //      Debug.Log("Collision");// test collision works with log message
            conThree = false;
            conFour = false;
            wireCon = false;
        }
        if (collision.gameObject.tag == "wall")
        {
            canRotate = false;
            canStretchUp = false;
            canStretchDown = false;
            hitWall = true;

             
        }
    }

    public IEnumerator CCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.

        yield return new WaitForSeconds(0.5f);// wait for a secound and change color
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
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ConnectorThree")
        {
      //      Debug.Log("Disconnecting 3");
            conThree = false;
          
            wireCon = false;
      //      Debug.Log("Wire2 Disconnected");
        }
        if (collision.gameObject.tag == "ConnectorFour")
        {
      //      Debug.Log("Disconnecting 4");
            conFour = false;
           
            wireCon = false;
      //      Debug.Log("Wire2 Disconnected");
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
