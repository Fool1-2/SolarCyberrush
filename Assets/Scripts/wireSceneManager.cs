using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; 
public class wireSceneManager : MonoBehaviour
{
    public BoxCollider2D bc;
    public static bool slidePuzzleCompleted;
    public TMP_Text promptText;
    public string curText = "";
    bool ishere;
    public GameObject player;
    public string SceneName;
    public bool isNextScene;
    public Vector3 offset = new Vector3(1, 2, 0);
    private Rigidbody2D body;

    [SerializeField]
    public SceneInfo SceneInfo;

    // Start is called before the first frame update
    void Start()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();

        body.position = transform.position + offset;
    }
    private void Awake()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        promptText.text = curText;
        if (Input.GetKeyDown(KeyCode.M))
        {
            slidePuzzleCompleted = true;
        }
        if (ishere)
        {
            Debug.Log("Here");
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

                   // SceneInfo.isNextScene = isNextScene;
                    //SceneManager.LoadScene(3);
                
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ishere = true;
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Bugged
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("left");
        ishere = false;
        promptText.text = "";

    }
}
