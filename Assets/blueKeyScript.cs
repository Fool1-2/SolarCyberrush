using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueKeyScript : MonoBehaviour
{
    public GameObject door1;
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
        if (collision.gameObject.tag == "blueDoor")
        {
            Destroy(door1);
            Glow.isGlowActive = false;
            Destroy(this.gameObject);

        }


    }
}