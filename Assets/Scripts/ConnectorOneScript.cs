using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorOneScript : MonoBehaviour
{
    public GameObject connectorTwo;
    public bool randomFinished;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());// starts time for color time
        connectorTwo = GameObject.FindWithTag("wireTwo"); // find gameobject with tag wireTwo
        connectorTwo.GetComponent<wireTwoScript>();// find wireTwo script
        randomFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomFinished == true)
        {
            if (wireTwoScript.wireCon == true)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.green;

            }


            if (wireTwoScript.wireCon == false)
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
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.gray;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        randomFinished = true; ;
        yield return null;
    }
}
