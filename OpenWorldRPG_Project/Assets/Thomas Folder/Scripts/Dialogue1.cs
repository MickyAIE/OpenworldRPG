using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue1 : MonoBehaviour {

    public TextMeshPro textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject nextb;
    public int sentnum1;
    public GameObject DialogueOb;
    public GameObject GUI;

    private void Start()
    {
        StartCoroutine(Type());
        sentnum1 = 0;
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            nextb.SetActive(true);
        }

        if (sentnum1 >= sentences.Length)
        {
            DialogueOb.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>().enabled = true;
            GUI.SetActive(true);

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
            sentnum1 += 1;
            print("next");
        } else
        {
            textDisplay.text = "";
            Cursor.lockState = CursorLockMode.Locked;
            sentnum1 += 1;
        }
    }
}
