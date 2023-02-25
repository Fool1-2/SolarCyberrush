using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaceHolderSaveScript : MonoBehaviour
{
    public List<GameObject> players;

    private void Update() {
        if (players.Count == 2)
        {
            Vector3 distance1 = this.gameObject.transform.position - players[0].transform.position;
            Vector3 distance2 = this.gameObject.transform.position - players[1].transform.position;
            if (this.gameObject.transform.position.x < distance1.x && this.gameObject.transform.position.y < distance1.y)
            {
                
            } 
        }
    }
}
