using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [TextArea(4, 4)]public string[] lines;
    [SerializeField]private TMP_Text lineText;
    public float lineSpeed;
    private int index;
    [HideInInspector]public IEnumerator CL;


    public IEnumerator CreateLines()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            lineText.text += c;
            yield return new WaitForSeconds(lineSpeed);
        }

        if (lineText.text == lines[index])
        {
            yield return new WaitForSeconds(5);
            NextLine();
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            lineText.text = string.Empty;
            StartCoroutine(CL);
        }
        else
        {
            GeneratorMiniGame.hasGameStarted = true;
            this.gameObject.SetActive(false);
        }
    }


}
