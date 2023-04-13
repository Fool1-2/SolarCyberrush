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
    public GameObject StreetBackgroundPlayer;
    public GameObject StreetBackgroundGrate;
    public bool autoText;
    public GameObject npc;
    public Vector2 npcPos;

    // Start is called before the first frame update
    void Start()
    {
        autoText = true;
        StreetBackgroundPlayer.SetActive(false);
        StreetBackgroundGrate.SetActive(false);
        npc.SetActive(false);
        textComponent.text = string.Empty;
        //StartSpeaking();
        StartCoroutine(BackgroundScroll());
    }

    // Update is called once per frame
    void Update()
    {
        //The background section
        if (index == 2)
        {

        }
        //The text section
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
    //Temporary scroll of backgrounds to make it seem like player came out of sewer
    IEnumerator BackgroundScroll()
    {
        yield return new WaitForSeconds(2);
        SewerBackground.SetActive(false);
        StreetBackgroundGrate.SetActive(true);
        yield return new WaitForSeconds(2);
        StreetBackgroundPlayer.SetActive(true);
        StreetBackgroundGrate.SetActive(false);
        npc.SetActive(true);
        StartSpeaking();
    }
}
