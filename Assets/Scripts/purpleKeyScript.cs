using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purpleKeyScript : MonoBehaviour
{
    public GameObject door1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "purpleDoor")
        {
            Destroy(door1);
            Glow.isGlowActive = false;
            Destroy(this.gameObject);

        }
    }



}
