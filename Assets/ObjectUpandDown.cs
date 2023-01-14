using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUpandDown : MonoBehaviour
{
    public GameObject upObj, downObj;
    enum motion { Up, Down}
    [SerializeField]motion currentMotion;
    [SerializeField] float motionSpeed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentMotion == motion.Up)
        {
            transform.position = Vector2.Lerp(transform.position, upObj.transform.position, motionSpeed * Time.deltaTime);
        }

        if (currentMotion == motion.Down)
        {
            transform.position = Vector2.Lerp(transform.position, downObj.transform.position, motionSpeed * Time.deltaTime);
        }
    }
}
