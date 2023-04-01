
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorScript : MonoBehaviour
{
    public GameObject wireToConnect;
    public bool randomFinished;
    public Sprite spriteOne, spriteTwo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());// starts time for color time
        randomFinished = false;
        GetComponent<SpriteRenderer>().sprite = spriteOne;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomFinished == true)
        {
            if (wireToConnect.GetComponent<wireScript>().isWireConnected == true)
            {
                GetComponent<SpriteRenderer>().sprite = spriteTwo;

            }


            if (wireToConnect.GetComponent<wireScript>().isWireConnected == false)
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
