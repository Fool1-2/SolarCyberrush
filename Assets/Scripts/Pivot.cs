using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    Transform player;


    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rot_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rot_z -= 180;
        //print(rot_z);
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);

        if (Glow.isGlowActive)
        {
            if (rot_z > -90f || rot_z < -270f)
            {
                //print("Left");
                PlayerMovement.playerflipped = false;
            }
            

            if (rot_z > -180f || rot_z < -180f && rot_z > -270f)
            {
                //print("Right");
                if (rot_z < -90f)
                {
                    PlayerMovement.playerflipped = true;
                }
            }
        }


    }
}
