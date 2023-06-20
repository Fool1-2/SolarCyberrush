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
}
