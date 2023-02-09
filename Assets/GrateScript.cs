using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GrateScript : MonoBehaviour
{
    public BoxCollider2D bc;
    public static bool slidePuzzleCompleted;
    public TMP_Text promptText;
    public string curText = "";

    // Start is called before the first frame update
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        promptText.text = curText;

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (slidePuzzleCompleted)
            {
                curText = "Press E to Crawl to the Exit"; 
            }
            else
            {
                curText = "Press E to Clear the Pipe";
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (slidePuzzleCompleted)
                {
                    collision.gameObject.GetComponent<Transform>().position = new Vector3(20, -4, 0);
                }
                else
                {
                    SceneManager.LoadScene(2);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        promptText.text = "";
    }
}
