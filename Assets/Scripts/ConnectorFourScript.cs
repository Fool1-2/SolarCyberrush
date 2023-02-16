using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorFourScript : MonoBehaviour
{
    public GameObject connectorFour;
    public bool randomFinished;
    public Sprite spriteOne, spriteTwo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());
        connectorFour = GameObject.FindWithTag("wireFour");
        connectorFour.GetComponent<wireFourScript>();
        randomFinished = false;
        GetComponent<SpriteRenderer>().sprite = spriteOne;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomFinished == true)
        {
            if (wireFourScript.wireCon == true)
            {
                GetComponent<SpriteRenderer>().sprite = spriteTwo;


            }


            if (wireFourScript.wireCon == false)
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
