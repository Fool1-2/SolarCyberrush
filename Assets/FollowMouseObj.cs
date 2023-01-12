using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseObj : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = diff;
    }
}
