using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript2 : MonoBehaviour
{
    PositionData posData;

    private void Awake()
    {
        transform.position = posData.posDataVec;
    }

    void Update()
    {

        posData.posDataVec.x = transform.position.x;
        posData.posDataVec.y = transform.position.y;
    }

    public void savePosition()
    {
        PlayerPrefs.SetFloat("P_X", posData.posDataVec.x);
        PlayerPrefs.SetFloat("P_Y", posData.posDataVec.y);
        PlayerPrefs.Save();
    }


}
