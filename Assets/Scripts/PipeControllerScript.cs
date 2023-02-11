using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PipeControllerScript : MonoBehaviour
{
    public GameObject player;
    public int directionX;
    public int directionY;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject;
        StartCoroutine(Moving());
    }

    IEnumerator Moving()
    {
        yield return new WaitForSeconds(2f);
        PlayerPipeObject.dirX = directionX;
        PlayerPipeObject.dirY = directionY;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StopCoroutine(Moving());
    }


}
