using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaceHolderSaveScript : MonoBehaviour
{
    int scene_index;
    int scene_saved;
    public GameObject player;
    public GameObject playerStartPos;
    public Vector2 playersPos;
    float player_X;
    float player_Y;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        player.transform.position = playerStartPos.transform.position;
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = playersPos;
        }
        else
        {
            return;
        }

        
    }

    

    public void Save_Scene()
    {
        scene_index = SceneManager.GetActiveScene().buildIndex;
        if (player != null)
        {
            PlayerPrefs.SetFloat("P_X", player.transform.position.x);
            PlayerPrefs.SetFloat("P_Y", player.transform.position.y);
        }
        PlayerPrefs.SetInt("Saved", scene_index);

        PlayerPrefs.Save();
    }

    public void Load_Scene()
    {
        playersPos.x = PlayerPrefs.GetFloat("P_X");
        playersPos.y = PlayerPrefs.GetFloat("P_Y");
        scene_saved = PlayerPrefs.GetInt("Saved");

        SceneManager.LoadSceneAsync(scene_saved);

    }
}
