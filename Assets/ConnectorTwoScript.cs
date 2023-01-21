using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConnectorTwoScript : MonoBehaviour
{
    public GameObject connectorOne;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());
        connectorOne = GameObject.FindWithTag("wireOne");
        connectorOne.GetComponent<wireScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (wireScript.conOne && wireScript.conTwo == true)
        {
            wireScript.wireCon = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        if (wireScript.conOne && wireScript.conTwo == false)
        {
            wireScript.wireCon = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
    IEnumerator ColorCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
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
