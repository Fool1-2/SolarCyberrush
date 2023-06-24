using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameManager = GameManagerScript;
using UnityEngine.SceneManagement;

public class temporaryPlayerTeleporterManagerObjectScript : MonoBehaviour
{
    public GameObject player;
    public Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && scene.buildIndex == 9)// if collides with other wires
        {


                SceneManager.LoadScene(8);
                Debug.Log("Cutscene");
            

        }       
        if (collision.gameObject.tag == "Player" && scene.buildIndex == 2)// if collides with other wires
        {
            
            player.transform.position = new Vector2(-8.98f, 36.84f);
            gameManager.UnloadSia();
        }


    }
}
