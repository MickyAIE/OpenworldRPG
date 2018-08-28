using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testNpcDialogue : MonoBehaviour {

    public Animator npcanim;
    public bool interactable;
    public GameObject QuestMarker;
    public GameObject Dialogue;
    public GameObject Interact;



	void Start () {
        npcanim = GetComponent<Animator>();
        npcanim.SetBool("IsIdle", false);
        interactable = false;
	}

    private void Update()
    {
        if (interactable == true && Input.GetKeyDown(KeyCode.F))
        {
            print("F");
            QuestMarker.SetActive(false);
            Dialogue.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            npcanim.SetBool("IsIdle", true);
            npcanim.SetBool("IsWaving", false);
        }
        else
            return;
        interactable = true;
        Interact.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            npcanim.SetBool("IsIdle", false);
            npcanim.SetBool("IsWaving", true);
        }
        else
            return;
        interactable = false;
        Interact.SetActive(false);
    }

}
