using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glow_ProjectileControl : MonoBehaviour
{
    
    public GameObject glowBullet;
    [SerializeField] GameObject currentGlowBullet;
    [SerializeField]Rigidbody2D rb;
    [SerializeField]float speed;
    [SerializeField]Transform player;
    [SerializeField]bool isShot;

    private void OnEnable() {
        currentGlowBullet = transform.GetChild(0).gameObject;
        currentGlowBullet.GetComponent<FollowMouse>().enabled = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (!isShot)
        {
            currentGlowBullet.transform.position = player.position;
        }


        rb = currentGlowBullet.GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shooting();
        }
    }

    void Shooting(){
        isShot = true;
        rb.AddForce(currentGlowBullet.transform.up * speed, ForceMode2D.Impulse);
        currentGlowBullet.GetComponent<FollowMouse>().enabled = false;
        StartCoroutine(respawnItem());
    }

    IEnumerator respawnItem(){
        yield return new WaitForSeconds(3f);
        Destroy(currentGlowBullet);
        currentGlowBullet = Instantiate(glowBullet, (Vector2)transform.position, Quaternion.identity);
        currentGlowBullet.transform.parent = gameObject.transform;
        currentGlowBullet.transform.localScale = new Vector3(6, 8, 7);
        isShot = false;
        
        
    }
}
