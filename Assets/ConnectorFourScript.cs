using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorFourScript : MonoBehaviour
{
    public GameObject connectorFour;
    public bool randomFinished;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());
        connectorFour = GameObject.FindWithTag("wireFour");
        connectorFour.GetComponent<wireFourScript>();
        randomFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomFinished == true)
        {
            if (wireFourScript.wireCon == true)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;

            }


            if (wireFourScript.wireCon == false)
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
        gameObject.GetComponent<Renderer>().material.color = Color.black;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.green;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.gray;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(1);
        randomFinished = true; ;
        yield return null;




    }

}
