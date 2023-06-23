using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panCamScript : MonoBehaviour
{
    Transform camTransform;
    Vector3 VectorDown, VectorUp, VectorRight;
    float motionSpeed = 5f;
    public float panTime;
    public bool goingUp, goingRight, goingDown;
    // Start is called before the first frame update
    void Start()
    {
        panTime = 0;
        camTransform = gameObject.transform;
        VectorDown = new Vector3(80.4f, 7.9f, -10f);
        VectorUp = new Vector3(20.2f, 40.7f, -10f);
        VectorRight = new Vector3(18f, 8f, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        if(l1Manager.panCamOn == true)
        {
            panTime++;
            if(panTime >= 0 && panTime <= 1500)
            {
                transform.position = Vector3.MoveTowards(transform.position, VectorDown, motionSpeed * Time.deltaTime);
                


            }

            if (panTime >= 1500 && panTime <= 3000)
            {
                transform.position = Vector3.MoveTowards(transform.position, VectorRight, motionSpeed * Time.deltaTime);


            }

            if (panTime >= 3000)
            {
                transform.position = Vector3.MoveTowards(transform.position, VectorUp, motionSpeed * Time.deltaTime);
            }
        }


        
    }

}
