using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject spawnLocation;
    private void OnEnable() {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = spawnLocation.transform.position;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(2);
            PlayerMovement.isPossessing = false;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            GrateScript.slidePuzzleCompleted = true;
            GameObject.FindGameObjectWithTag("WinBox").GetComponent<SwichScenes>().SceneSwitch("L1F2");
        }
    }
}
