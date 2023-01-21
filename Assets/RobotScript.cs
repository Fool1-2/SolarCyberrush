using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScript : MonoBehaviour
{
    public static bool isRobotActive;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isRobotActive = true;
        }
    }
    private void FixedUpdate()
    {
        if (isRobotActive)
        {
            rb.MovePosition(rb.position + new Vector2(0.1f,0));
        }
    }
}
