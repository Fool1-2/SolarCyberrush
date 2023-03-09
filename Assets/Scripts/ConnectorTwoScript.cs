using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ConnectorTwoScript : MonoBehaviour
{
    public GameObject connectorOne;
    public bool randomFinished;
    public Sprite spriteOne, spriteTwo;
    public static bool wirePuzzleCompleted;
    public string SceneName;
    public bool isNextScene;

    [SerializeField]
    public SceneInfo SceneInfo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorCoroutine());// start coroutine
        connectorOne = GameObject.FindWithTag("wireOne");// find gaemobject with tag wireOne
        connectorOne.GetComponent<wireScript>();// get that script
        randomFinished = false;
        GetComponent<SpriteRenderer>().sprite = spriteOne;

    }

    // Update is called once per frame
    void Update()
    {
        if (randomFinished == true)
        {
            if (wireScript.wireCon == true)
            {
                GetComponent<SpriteRenderer>().sprite = spriteTwo;
               

            }

            if (wireScript.wireCon == true && wireTwoScript.wireCon == true && wireThreeScript.wireCon == true && wireFourScript.wireCon == true && wireFiveScript.wireCon == true)
            {
                Debug.Log("ChangeNOW");
                wirePuzzleCompleted = true;
                SceneInfo.isNextScene = isNextScene;
                SceneManager.LoadScene(2);

            }


            if (wireScript.wireCon == false)
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
        yield return new WaitForSeconds(1);// wait for a secound and change color

        randomFinished = true; 
        yield return null;
    }
}
