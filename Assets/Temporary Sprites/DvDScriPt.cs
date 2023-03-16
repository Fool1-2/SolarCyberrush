using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DvDScriPt : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(Random.Range(18,25), Random.Range(6,15), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
