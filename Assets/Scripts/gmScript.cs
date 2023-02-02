using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class gmScript : MonoBehaviour
{
    public List<string> ObjectivesList;
    public TMP_Text objectiveText;
    public int objectiveNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        objectiveText.text = "Current Objective: " + ObjectivesList[objectiveNumber];
    }
}
