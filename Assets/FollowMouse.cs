using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotation_Z = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        rotation_Z -= 90;
        transform.rotation = Quaternion.Euler(0, 0, rotation_Z);
    }
}
