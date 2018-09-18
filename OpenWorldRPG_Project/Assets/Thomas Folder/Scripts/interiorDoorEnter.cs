using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interiorDoorEnter : MonoBehaviour {

    public GameObject Exit;
    public GameObject Player;
    public playerController controller;
    public GameObject EnterText;
    private bool EnterPress;




	// Use this for initialization
	void Start () {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        controller = p.GetComponent<playerController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (EnterPress == true && Input.GetKeyDown(KeyCode.F))
        {
            print("f");
            Player.transform.position = Exit.transform.position;
            controller.canEnter = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EnterText.SetActive(true);
        if(other.tag == ("Player") && controller.canEnter == true )
        {
            EnterPress = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnterText.SetActive(false);
        EnterPress = false;
    }
}
