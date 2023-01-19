using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow_ProjectileControl : MonoBehaviour
{
    
    public GameObject glowBullet;
    private GameObject currentGlowBullet;
    [SerializeField]Rigidbody2D rb;
    [SerializeField]float speed;
    [SerializeField]Vector2 scaleTest;
    [SerializeField]Transform player;

    private void OnEnable() {
        //glowBullet = Resources.Load<GameObject>("GlowAssets/RotateCircle");
        currentGlowBullet = transform.GetChild(0).gameObject;
        currentGlowBullet.GetComponent<FollowMouse>().enabled = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        


        rb = currentGlowBullet.GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shooting();
        }
    }

    void Shooting(){
        rb.AddForce(currentGlowBullet.transform.up * speed, ForceMode2D.Impulse);
        currentGlowBullet.GetComponent<FollowMouse>().enabled = false;
        StartCoroutine(respawnItem());
    }

    IEnumerator respawnItem(){
        yield return new WaitForSeconds(3f);
        Destroy(currentGlowBullet);
        currentGlowBullet = Instantiate(glowBullet, (Vector2)transform.position, Quaternion.identity);
        currentGlowBullet.transform.parent = gameObject.transform;
        
        
    }
}
