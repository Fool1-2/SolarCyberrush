using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftScript : MonoBehaviour
{
    public bool liftTriggered;
    Transform liftTransform;
    // Start is called before the first frame update
    void Start()
    {
        liftTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (liftTriggered)
        {

        }
    }
}
