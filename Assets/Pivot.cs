using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{

    [SerializeField]bool isFlipped;
    [SerializeField]float clampNum;

    void Update()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //diff.Normalize();

        float rot_Z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        float clampPos = Mathf.Clamp(rot_Z, -clampNum, clampNum);
        clampPos -= 180;

        if (clampPos < 270f  || clampPos > -270f)
        {
            if(!isFlipped) {transform.rotation = Quaternion.Euler(0, 0, clampPos);}
        }
        //if(isFlipped) {transform.rotation = Quaternion.Euler(0, 180, clampPos);}

    }
}
