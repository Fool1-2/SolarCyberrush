 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Narrative : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float characterSpeed;
    private int index;
    public GameObject SewerBackground;
    public GameObject StreetBackground;
    public GameObject StreetBackground2;
    public GameObject StreetBackground3;
    public bool autoText;
    // Start is called before the first frame update
    void Start()
    {
        autoText = true;
        StreetBackground.SetActive(false);
        StreetBackground2.SetActive(false);
        StreetBackground3.SetActive(false);
        textComponent.text = string.Empty;
        StartSpeaking();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            autoText = false;
            if (textComponent.text == lines[index])
            {
                NextLine();
                

            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        if(index == 2)
        {
            SewerBackground.SetActive(false);
            StreetBackground.SetActive(true);
        }
    }

    void StartSpeaking()
    {
        index = 0;
        StartCoroutine(TextBox());
        
    }


    IEnumerator TextBox()
    {
        foreach(char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(characterSpeed);
        }
        if (textComponent.text == lines[index] && autoText == true)
        {
            yield return new WaitForSeconds(5);
            NextLine();

        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TextBox());
        }
        else
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }
    }
}
