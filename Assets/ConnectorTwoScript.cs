using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConnectorTwoScript : MonoBehaviour
{
    public GameObject connectorOne;
    public bool randomFinished;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());// start coroutine
        connectorOne = GameObject.FindWithTag("wireOne");// find gaemobject with tag wireOne
        connectorOne.GetComponent<wireScript>();// get that script
        randomFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomFinished == true)
        {
            if (wireScript.wireCon == true)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.red;

            }


            if (wireScript.wireCon == false)
            {

                gameObject.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
    void FixedUpdate()
    {

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
        randomFinished = true; ;
        yield return null;
    }
}
