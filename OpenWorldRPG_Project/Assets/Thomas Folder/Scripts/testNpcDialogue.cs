using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testNpcDialogue : MonoBehaviour {

    public Animator npcanim;
    public bool interactable;
    public GameObject QuestMarker;
    public GameObject Dialogue;
    public GameObject Interact;
    public bool interacted;




	void Start () {
        npcanim = GetComponent<Animator>();
        npcanim.SetBool("IsIdle", false);
        npcanim.SetBool("IsTalking", false);
        interactable = false;
        interacted = false;
	}

    private void Update()
    {
        if (interactable == true && Input.GetKeyDown(KeyCode.F))
        {
            print("F");
            QuestMarker.SetActive(false);
            Dialogue.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            interacted = true;
            interactable = false;
            Interact.SetActive(false);
            npcanim.SetBool("IsIdle", false);
            npcanim.SetBool("IsWaving", false);
            npcanim.SetBool("IsTalking", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            npcanim.SetBool("IsIdle", true);
            npcanim.SetBool("IsWaving", false);
            npcanim.SetBool("IsTalking", false);
        }
        else
            return;
        if (interacted == false)
        {
            interactable = true;
            Interact.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            npcanim.SetBool("IsIdle", false);
            npcanim.SetBool("IsWaving", true);
            npcanim.SetBool("IsTalking", false);
        }
        else
            return;
        interactable = false;
        Interact.SetActive(false);
        Dialogue.SetActive(false);
    }

}
