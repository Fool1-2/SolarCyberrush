using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameManager = GameManagerScript;

public class temporaryPlayerTeleporterManagerObjectScript : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" )// if collides with other wires
        {
            player.transform.position = new Vector2(-14, 36);
            gameManager.UnLoadPuzzle("SIARoomScene");
        }

    }
}
