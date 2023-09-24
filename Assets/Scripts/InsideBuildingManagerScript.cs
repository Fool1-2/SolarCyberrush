using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameManager = GameManagerScript;

public class InsideBuildingManagerScript : MonoBehaviour, IInteractableScript
{
    public static Camera Mcamera;
    public static Camera camera2;
    public static bool atSIA;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        camera2 = Camera.main;
        atSIA = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            gameManager.UnLoadPuzzle("SIARoomScene");
            player.transform.position = new Vector2(5, 25);
            gameManager.CameraControl2();
            camera2.enabled = true;
            atSIA = false;
        }
        
        
 
    }
    public void Interact()
    {
        //print(PlayerMovement.isPossessing);
        //print(PlayerMovement.canMove);
        if (atSIA == false)
        {
            player.transform.position = new Vector2(893.8008f, 890.5856f);
            gameManager.LoadSIA();
            
        }
        

    }

    IEnumerator DoCheck()
    {
        yield return new WaitForSeconds(.1f);
        player.transform.position = new Vector2(900, 900);
        yield return null;

    }

}
