using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    private Transform player;
    private float rot_z;


    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerMovement.isPossessing)
        {
            Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;//Gets the position between the mouse and transform
            difference.Normalize();
    
            rot_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;// y/x in radians --> turns it into a degree
            rot_z -= 180;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        }
        else
        {
            Vector2 difference = Glow.currentPossessedObj.transform.position - transform.position;//Gets position between transform and possessed obj
            difference.Normalize();
    
            rot_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            rot_z -= 180;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
        }

        if (Glow.isGlowActive)
            {
                /*
                For you to truly understand this you will have to dm and get into a call so I can bring up jam board to go into
                a full depth analysis of why this works and why its stupid and why I hate coding. -Elyjah
                */

                if (rot_z > -60f || rot_z < -300f)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    PlayerMovement.playerflipped = false;
                }
                
    
                if (rot_z > -180f || rot_z < -180f && rot_z > -240f)
                {
                    if (rot_z < -90f)
                    {
                        transform.localScale = new Vector3(-1, -1, 1);
                        PlayerMovement.playerflipped = true;
                    }
                }
            }
    }
}
