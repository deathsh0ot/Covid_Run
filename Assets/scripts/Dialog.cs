using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    
    public bool continueDialogue = true;
    private float timer;
    public float timerTime;

    private int place;
    public int progressNum;
    public GameObject continueButton;
    private void Start()
    {
        timer = timerTime;
        StartCoroutine(Type());
    }

    IEnumerator Type()
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
        if(index < sentences.Length - 1)
        {
            index++;
            place++;
            textDisplay.text = "";
            
            StartCoroutine(Type());
        }
        else
        {
            continueButton.SetActive(false);
            textDisplay.text = "";
        }
    }

    private void Update()
    {
        if(place == progressNum)
        {
            continueDialogue = false;
        }
        else
        {
            continueDialogue = true;
        }

        if(textDisplay.text == sentences[index] && continueDialogue == true)
        {
            continueButton.SetActive(true);
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                NextSentence();
                timer = timerTime;
            }
        }
    }
}

