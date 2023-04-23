using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorFiveScript : MonoBehaviour
{
    public GameObject connectorFive;
    public bool randomFinished;
    public Sprite spriteOne, spriteTwo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());
        connectorFive = GameObject.FindWithTag("wireFive");
        connectorFive.GetComponent<wireFiveScript>();
        GetComponent<SpriteRenderer>().sprite = spriteOne;
        randomFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomFinished == true)
        {
            if (wireFiveScript.wireCon == true)
            {
                GetComponent<SpriteRenderer>().sprite = spriteTwo;


            }


            if (wireFiveScript.wireCon == false)
            {

                GetComponent<SpriteRenderer>().sprite = spriteOne;
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

        randomFinished = true; ;
        yield return null;




    }

}
