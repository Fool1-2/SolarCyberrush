using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorThreeScript : MonoBehaviour
{
    public GameObject connectorThree;
    public bool randomFinished;
    public Sprite spriteOne, spriteTwo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());
        connectorThree = GameObject.FindWithTag("wireThree");
        
        randomFinished = false;
        GetComponent<SpriteRenderer>().sprite = spriteOne;
    }

    // Update is called once per frame
    void Update()
    {
        if (randomFinished == true)
        {
            
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

