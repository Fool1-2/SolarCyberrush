using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "PlaceHolderSaveScript", menuName = "Persistence")]
public class GameManagerScript : MonoBehaviour
{
    public List<GameObject> players;

    private void Update()
    {
        if (players.Count == 2)
        {
            Vector3 distance1 = this.gameObject.transform.position - players[0].transform.position;
            Vector3 distance2 = this.gameObject.transform.position - players[1].transform.position;
            if (this.gameObject.transform.position.x < distance1.x && this.gameObject.transform.position.y < distance1.y)
            {

            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //  SceneManager.UnloadSceneAsync("L1F2");
            SceneManager.LoadSceneAsync("WirePuzzleScene", LoadSceneMode.Additive);// Loads the wire puzzle scene addative to the main scene

            SceneManager.SetActiveScene(SceneManager.GetSceneByName("WirePuzzleScene"));// sets wirepuzzle scene as active scene 
        }
        /*  if (Input.GetKeyDown(KeyCode.Q))
          {
             // SceneManager.UnloadSceneAsync("WirePuzzleScene");
              SceneManager.LoadSceneAsync("L1F2", LoadSceneMode.Additive);

              SceneManager.SetActiveScene(SceneManager.GetSceneByName("L1F2"));
          }*/



    }

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);// this object doesnt die

    }

    public void ShowPopup()
    {
        SceneManager.LoadSceneAsync("WirePuzzleScene", LoadSceneMode.Additive);// loads wire puzzle scene
    }

    public void ClosePopup()
    {
        SceneManager.UnloadSceneAsync("WirePuzzleScene");// unload wire puzzle scene(use when finished in scene)
    }
}

