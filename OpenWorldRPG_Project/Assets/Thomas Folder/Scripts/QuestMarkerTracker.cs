using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestMarkerTracker : MonoBehaviour {

    public GameObject[] QuestNum;
    public int ActiveQuest;
    public GameObject GUI;
    public GameObject Win;
    public EnemyHealth enemyHealth;
	// Use this for initialization
	void Start () {
        ActiveQuest = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        QuestNum[ActiveQuest].SetActive(true);

        if (enemyHealth.m_dead == true)
        {
            GUI.SetActive(false);
            Win.SetActive(true);
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }
}
