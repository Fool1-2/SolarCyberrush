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
    float flickerSpeed;
    L1LightManager l1lightManager;
    // Start is called before the first frame update
    void Start()
    {
        l1lightManager = GameObject.Find("Level1Manager").GetComponent<L1LightManager>();
        l2D = GetComponent<Light2D>();
        glow = GameObject.FindGameObjectWithTag("Player").GetComponent<Glow>();
        flickerSpeed = Random.Range(0f, 15f);
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
            flickerSpeed = Random.Range(5.5f, 10.5f);
            StartCoroutine(flicker());
        }
    }
    IEnumerator flicker()
    {
        powered = true;
        yield return new WaitForSeconds(Random.Range(0.8f, 2.5f));
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
