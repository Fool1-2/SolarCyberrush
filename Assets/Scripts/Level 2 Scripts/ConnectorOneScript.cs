
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorOneScript : MonoBehaviour
{
    public GameObject connectorTwo;
    public bool randomFinished;
    public Sprite spriteOne, spriteTwo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());// starts time for color time
        connectorTwo = GameObject.FindWithTag("wireTwo"); // find gameobject with tag wireTwo
        connectorTwo.GetComponent<wireTwoScript>();// find wireTwo script
        randomFinished = false;
        GetComponent<SpriteRenderer>().sprite = spriteOne;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomFinished == true)
        {
            if (wireTwoScript.wireCon == true)
            {
                GetComponent<SpriteRenderer>().sprite = spriteTwo;


            }


            if (wireTwoScript.wireCon == false)
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

        randomFinished = true; 
        yield return null;
    }
}
