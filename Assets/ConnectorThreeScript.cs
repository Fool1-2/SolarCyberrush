using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorThreeScript : MonoBehaviour
{
    public GameObject connectorThree;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());
        connectorThree = GameObject.FindWithTag("wireThree");
        connectorThree.GetComponent<wireThreeScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (wireThreeScript.conFive && wireThreeScript.conSix == true)
        {
            wireThreeScript.wireCon = true;
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }

        if (wireThreeScript.conFive && wireThreeScript.conSix == false)
        {
            wireThreeScript.wireCon = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
    IEnumerator ColorCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}

