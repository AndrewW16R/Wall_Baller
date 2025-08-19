using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelectSaveSystem : MonoBehaviour
{
    public GameObject timerObject;
    public Timer timer;


    // Start is called before the first frame update
    void Start()
    {
        timerObject = GameObject.Find("GameManager");

        if (timerObject != null)
        {
            timer = timerObject.GetComponent<Timer>();
            LoadDifficulty(); //Sets difficulty String in the timer script to whatever the difficulty PlayerPref is
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDifficultyToStandard() //Sets Difficulty PlayerPref to "Standard"
    {
        PlayerPrefs.SetString("Difficulty", "Standard");
    }

    public void SetDifficultyToEasy() //Sets Difficulty PlayerPref to "Easy"
    {
        PlayerPrefs.SetString("Difficulty", "Easy");
    }

    public void SetDifficultyToHard() //Sets Difficulty PlayerPref to "Hard"
    {
        PlayerPrefs.SetString("Difficulty", "Hard");
    }

    public void SetDifficultyToExpert() //Sets Difficulty PlayerPref to "Standard"
    {
        PlayerPrefs.SetString("Difficulty", "Expert");
    }

    public void LoadDifficulty() //Sets difficulty String in the timer script to whatever the difficulty PlayerPref is
    {
        timer.difficulty = PlayerPrefs.GetString("Difficulty");
    }
}
