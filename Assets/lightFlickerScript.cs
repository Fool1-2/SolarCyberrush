using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class lightFlickerScript : MonoBehaviour, ILightAbility
{
    Light2D l2D;
    Glow glow;
    bool powered = false;
    float timer;
    float flickerSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        l2D = GetComponent<Light2D>();
        glow = GameObject.FindGameObjectWithTag("Player").GetComponent<Glow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!powered)
        {
            l2D.enabled = false;
            timer += Time.deltaTime;
        }
        else
        {
            l2D.enabled = true;
        }
        if (timer > flickerSpeed)
        {
            timer = 0;
            flickerSpeed = Random.Range(2.5f, 4.5f);
            StartCoroutine(flicker());
        }
    }
    IEnumerator flicker()
    {
        powered = true;
        yield return new WaitForSeconds(Random.Range(0.1f, 0.8f));
        powered = false;
    }

    public void ActivatePower()
    {
        StartCoroutine(glowPowered());
    }

    IEnumerator glowPowered()
    {
        powered = true;
        StopCoroutine(flicker());
        yield return new WaitForSeconds(10);
        powered = false;
    }
}
