using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePlayerMove : MonoBehaviour
{
    public GameObject[] pipes;
    public PipeControllerScript currentPipe;
    public Transform playerObject;
    public static bool isMoving;
    public static int dirX;
    public static int dirY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = true;
        }

        if (isMoving)
        {
            transform.Translate(dirX * Time.deltaTime, dirY * Time.deltaTime, transform.position.z);
        }

        if (currentPipe != null)
        {
            StopCoroutine(outOfPipe());
        }
        else
        {
            StartCoroutine(outOfPipe());
        }
    }

    IEnumerator outOfPipe()
    {
        yield return new WaitForSeconds(2f);
        print("WORK");
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentPipe = collision.gameObject.GetComponent<PipeControllerScript>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        currentPipe = collision.gameObject.GetComponent<PipeControllerScript>();
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentPipe = null;
    }
}
