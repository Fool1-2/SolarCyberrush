using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorOneScript : MonoBehaviour
{
    public GameObject connectorTwo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());
        connectorTwo = GameObject.FindWithTag("wireTwo");
        connectorTwo.GetComponent<wireTwoScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        if (wireTwoScript.conThree && wireTwoScript.conFour == true)
        {
            wireTwoScript.wireCon = true;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        if (wireTwoScript.conThree && wireTwoScript.conFour == false)
        {
            wireTwoScript.wireCon = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
    IEnumerator ColorCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.gray;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
