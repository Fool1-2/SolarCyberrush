using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrateBackCollider : MonoBehaviour
{
    bool ishere;
    public GrateScript gs;
    // Start is called before the first frame update
    void Start()
    {
        gs = GameObject.Find("GrateManager").GetComponent<GrateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ishere)
        {
            Debug.Log("hji");
            gs.sendPlayerBack();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ishere = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ishere = false;
    }
}
