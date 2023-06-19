using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class floatingPlatformObj : MonoBehaviour
{
    Rigidbody2D rb;
    public static bool floating;


    private void Start()
    {
        
        //floating = true;
        rb = GetComponent<Rigidbody2D>();
        floating = true;



    }
    // Update is called once per frame
    void Update()
    {
 

        if (rb.gravityScale > 10 || rb.gravityScale < 10)
        {
            rb.gravityScale = 10;
        }

    }

     

}
