using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerObjectScript : MonoBehaviour
{
    private GSManager GS;
    [SerializeField] float Initialtimer;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        GS = GameObject.Find("GeneratorSceneManager").GetComponent<GSManager>();
        timer = Initialtimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (GS.hasGameStarted)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = Initialtimer;
        }
        if (timer < 0)
        {
            GS.notePlayed();
        }
    }

}
