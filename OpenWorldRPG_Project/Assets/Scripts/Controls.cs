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
        controls.text = ("");
        pressPause.text = ("Press Enter for controls");

	}
	
	// Update is called once per frame
	void Update ()
    {

        Paused();

	}

    void Paused()
    {
        if (paused == false && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Time.timeScale = 0;

            pause.text = ("PAUSED");
            controls.text = ("W A S D to move" +
                "F to interact" +
                "J to equip weapon" +
                "K to unequip Weapon" +
                "Mouse to Look around" +
                "Space to jump" +
                "Shift to run" +
                "Left click to attack" +
                "Right click to block" +
                "I to open inventory" +
                "Esc to exit");
            pressPause.text = ("Press Enter to exit menu");
            paused = true;

        }
        if (paused == true && Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Time.timeScale = 1;

            pause.text = ("");
            controls.text = ("");
            pressPause.text = ("Press Enter for controls");

            paused = false;
        }
    }
}
