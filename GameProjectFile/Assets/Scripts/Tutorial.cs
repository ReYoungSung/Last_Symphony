using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TMP_Text tutorialTxt;

    string dialogue;
    void Start()
    {
        dialogue = "Before you start, you should know some movements for using througout Symphony No. 9";
        StartCoroutine(Typing(dialogue));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Typing(string talk)
    {
        tutorialTxt.text = null;

        if(talk.Contains("  ")) talk = talk.Replace(" ", "\n");
        for(int i = 0; i < talk.Length; i++)
        {
            tutorialTxt.text += talk[i];
            yield return new WaitForSeconds(0.09f);
        }
    }
}
