using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject pauseMenu;
    public GameObject restartConfirmMenu;
    public GameObject mainMenuConfirmMenu;
    public GameObject gameOverMenu;

    private GameObject gameManagerObject;
    public GameManager gameManager;

    public Text textPauseMenuBallLevel;
    public Text textPauseMenuBallExp;
    public Text textGameOverMenuBallLevel;
    public Text textGameOverMenuBallExp;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();

        TogglePauseMenu(false);
        ToggleRestartConfirmMenu(false);
        ToggleMainMenuConfirmMenu(false);
        ToggleGameOverMenu(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TogglePauseMenu(bool isMenuEnabled)
    {
        if (isMenuEnabled == true)
        {
            pauseMenu.SetActive(true);
            gameManager.GetBallInfo(); //Makes game manager retrieve updated ball info
            textPauseMenuBallLevel.text = gameManager.ballLevel.ToString();
            textPauseMenuBallExp.text = gameManager.ballExp.ToString();
        }
        else
        {
            pauseMenu.SetActive(false);
        }
    }

    public void ToggleRestartConfirmMenu(bool isMenuEnabled)
    {
        if (isMenuEnabled == true)
        {
            restartConfirmMenu.SetActive(true);
        }
        else
        {
            restartConfirmMenu.SetActive(false);
        }
    }

    public void ToggleMainMenuConfirmMenu(bool isMenuEnabled)
    {
        if (isMenuEnabled == true)
        {
            mainMenuConfirmMenu.SetActive(true);
        }
        else
        {
            mainMenuConfirmMenu.SetActive(false);
        }
    }

    public void ToggleGameOverMenu(bool isMenuEnabled)
    {
        if (isMenuEnabled == true)
        {
            gameOverMenu.SetActive(true);
            gameManager.GetBallInfo(); //Makes game manager retrieve updated ball info
            textGameOverMenuBallLevel.text = gameManager.ballLevel.ToString();
            textGameOverMenuBallExp.text = gameManager.ballExp.ToString();
        }
        else
        {
            gameOverMenu.SetActive(false);
        }
    }

    public void ClearPauseMenus()
    {
        TogglePauseMenu(false);
        ToggleRestartConfirmMenu(false);
        ToggleMainMenuConfirmMenu(false);
    }
}
