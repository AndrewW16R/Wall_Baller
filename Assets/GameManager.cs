using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public GameObject playerObject;
    public PlayerMovement playerMovement;

    public GameObject gameOverZoneObject;
    public GameOverZone gameOverZone;

    public GameObject gameOverMenu;
    private string currentSceneName;

    // Start is called before the first frame update
    void Start()
    {
        SetTimeScale(1);

        isGameOver = false;
        Cursor.visible = false;

        playerObject = GameObject.FindWithTag("Player");
        playerMovement = playerObject.GetComponent<PlayerMovement>();

        gameOverZoneObject = GameObject.FindWithTag("GameOverZone");
        gameOverZone = gameOverZoneObject.GetComponent<GameOverZone>();

        gameOverMenu = GameObject.Find("GameOverCanvas");
        gameOverMenu.SetActive(false);

        currentSceneName = SceneManager.GetActiveScene().name;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneName);
    }

    public void SetTimeScale(float timescale)
    {
        Time.timeScale = timescale;
    }

    public void ActivateGameOver()
    {
        Cursor.visible = true;
        gameOverMenu.SetActive(true);
        SetTimeScale(0);
    }
}
