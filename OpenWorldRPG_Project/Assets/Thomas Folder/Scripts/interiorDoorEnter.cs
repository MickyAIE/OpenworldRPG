using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interiorDoorEnter : MonoBehaviour {

    public GameObject Exit;
    public GameObject Player;
    public playerController controller;
    public GameObject EnterText;
    private bool EnterPress;
    private bool isCol;
    public bool QuestDoor;
    public GameObject QM;
    public bool OneTimeOpen;
    public bool EnterAllow;




	// Use this for initialization
	void Start () {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        controller = p.GetComponent<playerController>();
        isCol = false;
        EnterAllow = true;

    }
	
	// Update is called once per frame
	void Update () {
		if (EnterPress == true && Input.GetKeyDown(KeyCode.F) && EnterAllow == true && isCol == true)
        {
            print("f");
            Player.transform.position = Exit.transform.position;
            controller.canEnter = false;
            if (OneTimeOpen)
            {
                EnterAllow = false;
            }

            if (QuestDoor == true)
            {
                QM.SetActive(false);
                GameObject.FindGameObjectWithTag("QuestTracker").GetComponent<QuestMarkerTracker>().ActiveQuest += 1;
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == ("Player") && controller.canEnter == true )
        {
            isCol = true;
            
        }
    }

    private void OnMouseOver()
    {
        if(isCol == true && EnterAllow == true)
        {
            EnterText.SetActive(true);
            EnterPress = true;
        }
        else
        {
            EnterText.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnterText.SetActive(false);
        EnterPress = false;
    }
}
