using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairScript: MonoBehaviour
{
    [SerializeField] float height;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, height  + transform.position.y + 0.05f, collision.gameObject.transform.position.z);
        //Does a thing
        collision.gameObject.transform.position += new Vector3(-0.5f, height, 0);
        Debug.Log("stepped");
    }
}
