using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
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
        if (collision.gameObject.tag == "pinkDoor")
        {
            Destroy(door1);
            Destroy(door2);
            Glow.isGlowActive = false;
            Destroy(this.gameObject);

        }


    }
}
