using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    private bool panelScreens;
    [SerializeField]private bool once;
    [SerializeField]private Canvas pausePanel;
    [SerializeField]private GameObject L1canvas;

    [SerializeField]private Button resumeButton;

    // Update is called once per frame
    void Update()
    {

        if (!pausePanel.enabled)
        {
            once = false;
        }

        if (!once)
        {
            if (L1canvas != null)
            {
                if (pausePanel.enabled && L1canvas.activeInHierarchy)
                {
                    resumeButton.Select();
                    once = true;
                }
            }
            else
            {
                return;
            }
        }
    }

    public void OnceFunc()
    {
        once = false;
    }

    

    
}
