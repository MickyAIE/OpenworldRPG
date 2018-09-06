using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour

{
    public Text levelText;
    public Text experienceText;
    public Text requiredExperienceText;
    public Slider experienceSlider;

    public static int experience;
    int requiredExperience;             //To level up
    int playerLevel;
    public float experienceGrowth;

    private void Start()
    { 
        playerLevel = 1;
        levelText.text = "Lv 1";

        experience = 0;
        experienceText.text = "" + experience;

        requiredExperience = 100;
        requiredExperienceText.text = "/" + requiredExperience;

        experienceSlider.value = experience;
        experienceSlider.maxValue = requiredExperience;

        experienceGrowth = 1.50f;
    }

    private void Update()
    {

            experienceSlider.value = experience;
            experienceText.text = " " + experience;

        if (experienceSlider.value >= experienceSlider.maxValue)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        experienceSlider.value = experience;

        requiredExperience = (int)(requiredExperience * experienceGrowth);
        experienceSlider.maxValue = requiredExperience;

        playerLevel += 1;
        levelText.text = "Lv " + playerLevel;

        requiredExperienceText.text = "/" + requiredExperience;
    }
}

