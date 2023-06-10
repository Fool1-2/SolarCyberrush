using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideBuildingManagerScript : MonoBehaviour //Add elyjahs fancy interact thing
{
    public static bool isInsideBuilding;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInsideBuilding)
        {
            mainCamera.transform.position = new Vector3(500, 500);
        }
    }

    
}
