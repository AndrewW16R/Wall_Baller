using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelectSaveSystem : MonoBehaviour
{
    public GameObject timerObject;
    public Timer timer;

    public string dif;

    // Start is called before the first frame update
    void Start()
    {
        timerObject = GameObject.Find("GameManager");

        if (timerObject != null)
        {
            timer = timerObject.GetComponent<Timer>();
            LoadDifficulty();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetDifficultyToStandard()
    {
        PlayerPrefs.SetString("Difficulty", "Standard");
    }

    public void SetDifficultyToHard()
    {
        PlayerPrefs.SetString("Difficulty", "Hard");
    }

    public void LoadDifficulty()
    {
        timer.difficulty = PlayerPrefs.GetString("Difficulty");
    }
}
