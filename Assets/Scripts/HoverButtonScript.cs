using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class HoverButtonScript : MonoBehaviour
{
    public Light2D[] lightsAr; 

    private void OnMouseOver() {
        foreach (Light2D light in lightsAr)
        {
            light.enabled = true;
        }
    }

    private void OnMouseExit() {
        foreach (Light2D light in lightsAr)
        {
            light.enabled = false;
        }
    }
}
