using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorThreeScript : MonoBehaviour
{
    public GameObject connectorThree;
    public bool randomFinished;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());
        connectorThree = GameObject.FindWithTag("wireThree");
        connectorThree.GetComponent<wireThreeScript>();
        randomFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomFinished == true)
        {
            if (wireThreeScript.wireCon == true)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;

            }


            if (wireThreeScript.wireCon == false)
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
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);
        randomFinished = true; ;
        yield return null;




    }

}

