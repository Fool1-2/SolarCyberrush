using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "PlaceHolderSaveScript", menuName = "Persistence")]
public class PlaceHolderSaveScript : MonoBehaviour
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

       /* if (Input.GetKey(KeyCode.E))
        {
            SceneManager.UnloadSceneAsync("L2F1L1F2");
            SceneManager.LoadSceneAsync("WirePuzzleScene", LoadSceneMode.Additive);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName("WirePuzzleScene"));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            SceneManager.UnloadSceneAsync("WirePuzzleScene");
            SceneManager.LoadSceneAsync("L2F1L1F2", LoadSceneMode.Additive);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName("L2F1L1F2"));
        }*/



    }

    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    public void ShowPopup()
    {
        SceneManager.LoadSceneAsync("WirePuzzleScene", LoadSceneMode.Additive);
    }

    public void ClosePopup()
    {
        SceneManager.UnloadSceneAsync("WirePuzzleScene");
    }
}

