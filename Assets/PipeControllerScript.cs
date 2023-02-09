using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PipeControllerScript : MonoBehaviour
{
    public GameObject player;
    public int directionX;
    public int directionY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject;
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(1.5f);
        PipePlayerMove.dirX = directionX;
        PipePlayerMove.dirY = directionY;
    }



    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(Moving());
    }


}
