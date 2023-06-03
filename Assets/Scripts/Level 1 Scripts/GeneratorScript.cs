using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class GeneratorScript : MonoBehaviour, IInteractableScript
{
    public UnityEvent GeneratorEvent;
    public int generatorNum;

    public void Interact(){
        GeneratorEvent.Invoke();

    }
}
