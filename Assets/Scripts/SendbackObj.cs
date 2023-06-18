using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using gameManager = GameManagerScript;

public class SendbackObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        gameManager.CameraControl();
    }
}
