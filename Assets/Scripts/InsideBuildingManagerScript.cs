using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameManager = GameManagerScript;

public class InsideBuildingManagerScript : MonoBehaviour, IInteractableScript
{
    public static Camera Mcamera;
    public Camera camera2;
    public static bool atSIA;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Mcamera = camera2;
        camera2.enabled = true;
        atSIA = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            player.transform.position = new Vector2(4, 24);
            gameManager.CameraControl2();
            PlayerMovement.canMove = true;
            atSIA = false;
            
        }
        
 
    }
    public void Interact()
    {
        //print(PlayerMovement.isPossessing);
        //print(PlayerMovement.canMove);
        if (!gameManager.isSceneLoaded)
        {
            player.transform.position = new Vector2(900, 900);
           // StartCoroutine(DoCheck());
           PlayerMovement.canMove = true;
            gameManager.LoadSIA();
            camera2.enabled = false;
            
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            camera2.enabled = false;
            QuitScene.Camera.enabled = true;
            player.transform.position = new Vector2(900, 900);
        }
        

    }

    IEnumerator DoCheck()
    {
        yield return new WaitForSeconds(.1f);
        player.transform.position = new Vector2(900, 900);
        yield return null;

    }

}
