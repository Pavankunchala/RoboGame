using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed = 0.02f;

    public GameObject continueButton;


    private void Start()
    {
        StartCoroutine(type());
    }

    private void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
     
    }

    IEnumerator type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }


      
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(index < sentences.Length -1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(type());

        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }
}
