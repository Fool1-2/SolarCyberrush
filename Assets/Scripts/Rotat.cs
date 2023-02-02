using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            float rotate_Z = Mathf.Atan2(mouse_Pos.y, mouse_Pos.x) * Mathf.Rad2Deg;
            rotate_Z -= 90;
            transform.rotation = Quaternion.Euler(0, 0, rotate_Z);
        }
    }
}