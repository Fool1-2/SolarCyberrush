using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReverseGrateScript : MonoBehaviour, IInteractableScript
{
    public Vector2 gratePosition;
    [SerializeField]GrateScript gs;
    bool ishere;
    public TMP_Text curText;
    [SerializeField]GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //gratePosition = new Vector2(11, 8);
        gs = GameObject.Find("GrateManager").GetComponent<GrateScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GrateScript.slidePuzzleCompleted)
        {
            curText.text = "Press E to Climb Back";
        }
        else
        {
            curText.text = "";
        }
    }

    public void Interact()
    {
        gs.delayActive = true;
        player.transform.position = gratePosition;
    }

    private void OnTriggerExit2D(Collider2D other) {
        ishere = false;
    }

}
