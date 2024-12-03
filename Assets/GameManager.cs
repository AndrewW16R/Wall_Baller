using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public GameObject playerObject;
    public PlayerMovement playerMovement;

    public GameObject gameOverZoneObject;
    public GameOverZone gameOverZone;

    public GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;

        playerObject = GameObject.FindWithTag("Player");
        playerMovement = playerObject.GetComponent<PlayerMovement>();

        gameOverZoneObject = GameObject.FindWithTag("GameOverZone");
        gameOverZone = gameOverZoneObject.GetComponent<GameOverZone>();

        gameOverMenu = GameObject.Find("GameOverCanvas");
        gameOverMenu.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateGameOver()
    {
        playerMovement.SetTimeScale(0);
    }
}
