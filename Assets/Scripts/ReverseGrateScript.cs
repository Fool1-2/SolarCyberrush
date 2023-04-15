using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReverseGrateScript : MonoBehaviour
{
    public Vector2 gratePosition;
    [SerializeField]GrateScript gs;
    bool ishere;
    public TMP_Text curText;
    [SerializeField]GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //gratePosition = new Vector2(11, 8);
        gs = GameObject.Find("GrateManager").GetComponent<GrateScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GrateScript.slidePuzzleCompleted)
        {
            curText.text = "Press E to Climb Back";
            if (ishere && Input.GetKeyDown(KeyCode.E))
            {
                player.transform.position = gratePosition;
            }
        }
        else
        {
            curText.text = "";
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ishere = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                gs.delayActive = true;
                collision.gameObject.GetComponent<Transform>().position = gratePosition;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            ishere = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                gs.delayActive = true;
                other.gameObject.GetComponent<Transform>().position = gratePosition;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        ishere = false;
    }

}
