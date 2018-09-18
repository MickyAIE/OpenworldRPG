using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour {

    public Text controls;
    public Text pause;
    public Text pressPause;

    private bool paused = false;
    
	// Use this for initialization
	void Start () {

        pause.enabled = false;
        controls.enabled = false;

        pause.text = ("");
        pressPause.text = ("Press T for controls");
        paused = false;

	}
	
	// Update is called once per frame
	void Update ()
    {

        Paused();

	}

    void Paused()
    {
        if (paused == false && Input.GetKeyUp(KeyCode.T))
        {
            controls.enabled = true;
            pause.enabled = true;
            Time.timeScale = 0;

            pause.text = ("PAUSED");
            pressPause.text = ("Press Esc to exit menu");
            paused = true;

        }
        if (paused == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            controls.enabled = false;
            pause.enabled = false;

            pause.text = ("");
            pressPause.text = ("Press T for controls");

            paused = false;
        }
    }
}
