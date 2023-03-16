using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseGrateScript : MonoBehaviour
{
    public Vector2 gratePosition;
    GrateScript gs;
    // Start is called before the first frame update
    void Start()
    {
        gratePosition = new Vector2(11, 8);
        gs = GameObject.Find("GrateManager").GetComponent<GrateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gs.delayActive = true;
                collision.gameObject.GetComponent<Transform>().position = gratePosition;
                Debug.Log("thing");
            }
        }
    }

}
