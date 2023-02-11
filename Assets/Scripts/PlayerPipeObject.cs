using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPipeObject : MonoBehaviour
{
    public PipeControllerScript currentPipe;
    public static bool isMoving;
    public bool isOutOfPipe;
    public static int dirX;
    public static int dirY;

    IEnumerator OutOfPipe(float time)
    {
        yield return new WaitForSeconds(time);
        print("WORK");
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    private void OnEnable() {
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOutOfPipe)
        {
            Destroy(this.gameObject);
        }

        if (isMoving)
        {
            transform.Translate(dirX * Time.deltaTime, dirY * Time.deltaTime, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOutOfPipe = false;
        currentPipe = collision.gameObject.GetComponent<PipeControllerScript>();
        if (collision.gameObject.tag == "WinBox")
        {
            GrateScript.slidePuzzleCompleted = true;
            collision.gameObject.GetComponent<SwichScenes>().SceneSwitch("L1F2");
        }
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOutOfPipe = true;
    }
}
