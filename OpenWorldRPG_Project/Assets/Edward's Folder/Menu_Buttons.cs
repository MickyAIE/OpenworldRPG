using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu_Buttons : MonoBehaviour {

    public Button Quit;
    public Button Play;
    public Button Settings;

    // Use this for initialization
    void Start() {
        Button qbtn = Quit.GetComponent<Button>();
        qbtn.onClick.AddListener(QuitProgram);

        Button pbtn = Play.GetComponent<Button>();
        pbtn.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update() {

    }

    void QuitProgram()
    {
        Application.Quit();
    }

    void StartGame()
    {

        SceneManager.LoadScene("Demo_Scene");
    }
}
