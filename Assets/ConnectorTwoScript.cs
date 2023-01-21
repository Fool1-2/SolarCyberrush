using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConnectorTwoScript : MonoBehaviour
{
    public GameObject connectorOne;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());// start coroutine
        connectorOne = GameObject.FindWithTag("wireOne");// find gaemobject with tag wireOne
        connectorOne.GetComponent<wireScript>();// get that script
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (wireScript.conOne && wireScript.conTwo == true)// if these values in this script are true
        {
            wireScript.wireCon = true;// the wire connection is true
            gameObject.GetComponent<Renderer>().material.color = Color.red;// change connection color to red
        }

        if (wireScript.conOne && wireScript.conTwo == false)
        {
            wireScript.wireCon = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;// if the above values are false make white again
        }
    }
    IEnumerator ColorCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);// wait for a secound and change color
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
