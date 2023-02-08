using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorFiveScript : MonoBehaviour
{
    public GameObject connectorFive;
    public bool randomFinished;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());
        connectorFive = GameObject.FindWithTag("wireFive");
        connectorFive.GetComponent<wireFiveScript>();
        randomFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomFinished == true)
        {
            if (wireFiveScript.wireCon == true)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.magenta;

            }


            if (wireFiveScript.wireCon == false)
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
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.gray;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);
        randomFinished = true; ;
        yield return null;




    }

}
