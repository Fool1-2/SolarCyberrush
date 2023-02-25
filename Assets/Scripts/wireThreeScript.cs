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
    Collider2D boxCollider;
    Rotat rotat;
    public static bool conFive;
    public static bool conSix;
    public static bool wireCon;
    public bool wireSelected;
    public float yScale;
    public float xScale;
    public float rotate;
    public bool canRotate;
    public bool canStretchUp;
    public bool canStretchDown;
    public bool hitWall;
    public Vector3 offset;
    SpriteRenderer SR;




    private void Start()
    {
        mouseOn = false;
        boxSize = transform.localScale;
        rotat = gameObject.GetComponent<Rotat>();
        boxCollider = GetComponent<Collider2D>();
        wireSelected = false;
        gameObject.GetComponent<SpriteRenderer>();
        boxSize.x = 5.338786f;
        canStretchUp = true;
        canStretchDown = true;
        canRotate = true;
        rotate = -15.267f;
        yScale = transform.localScale.y;
        xScale = transform.localScale.x;


        // Debug.Log("Hello world");
        conFive = false;
        wireCon = false;
        conSix = false;
    }

    private void Update()
    {
         Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Gets the camera position from the screen and puts into the world.

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
            rb.MovePosition(new Vector3(mousePos.x, mousePos.y));
            // transform.position = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            

            // Set the new position of the object
            //rb.MovePosition(newPos);
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wireTwo" || collision.gameObject.tag == "wireThree" || collision.gameObject.tag == "wireFive" || collision.gameObject.tag == "wireOne")// if collides with other wires
        {
            boxCollider.isTrigger = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);// reload scene
            Debug.Log("Collision");// test collision works with log message
            conFive = false;
            wireCon = false;
            conSix = false;
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
            yield return new WaitForSeconds(1);
            boxCollider.isTrigger = true;

            yield return null;
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
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ConnectorFive")
        {
            Debug.Log("Disconnecting 5");
            conFive = false;
            wireCon = false;
            Debug.Log("Wire3 Disconnected");
        }
        if (collision.gameObject.tag == "ConnectorSix")
        {
            Debug.Log("Disconnecting 6");
            conSix = false;
            wireCon = false;
            Debug.Log("Wire3 Disconnected");
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
