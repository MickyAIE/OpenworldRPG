using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interiorDoorEnter : MonoBehaviour {

    public GameObject Exit;
    public GameObject Player;
    public playerController controller;




	// Use this for initialization
	void Start () {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        controller = p.GetComponent<playerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == ("Player") && controller.canEnter == true)
        {
            Player.transform.position = Exit.transform.position;
            controller.canEnter = false;
        }
    }
}
