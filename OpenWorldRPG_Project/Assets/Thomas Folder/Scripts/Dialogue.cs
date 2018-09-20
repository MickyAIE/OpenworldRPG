using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour {

    public TextMeshPro textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject nextb;
    public int sentnum;
    public GameObject DialogueOb;
    public GameObject GUI;
    public GameObject DialogueManager;

    private void Start()
    {
        StartCoroutine(Type());
        sentnum = 0;
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            nextb.SetActive(true);
        }

        if (sentnum >= sentences.Length)
        {
            DialogueOb.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = true;
            GUI.SetActive(true);
            DialogueManager.SetActive(false);

        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            NextSentence();
            print("NextSen");
        }

        
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
        nextb.SetActive(false);
        
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            sentnum += 1;
            print("next");
        } else
        {
            textDisplay.text = "";
            Cursor.lockState = CursorLockMode.Locked;
            sentnum += 1;
        }
    }
}
