using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int levelToRestart;
    [SerializeField] private GameObject pauseScreen;
    // [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject inGameScreen;
    private bool isGameActive=false;
    // void Start()
    // {
    //     titleScreen.gameObject.SetActive(true);
    //     // gameOverText.gameObject.SetActive(false);
    //     // timeScoreText.gameObject.SetActive(false);
    // }

    private void Awake()
    {
        // titleScreen.gameObject.SetActive(true);
        // inGameScreen.gameObject.SetActive(false);
        pauseScreen.SetActive(false);
    }
    
    public void DisplayGameOver()
    {
        // isGameActive =  false;
        // gameOverText.gameObject.SetActive(true);
        // timeScoreText.gameObject.SetActive(false);
        // ghoulSpawner.isSpawning = false; // Stop spawning ghouls when the game is over
    }

    public bool IsGameActive()
    {
        return isGameActive;
    }

    public void RestartGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // StartGame();
        Time.timeScale = 1;
        SceneManager.LoadScene(levelToRestart);

        
    }

    public void StartGame()
    {
        isGameActive =  true;
        SceneManager.LoadScene(2);
        // SceneManager.LoadScene(1);
        // titleScreen.gameObject.SetActive(false);
        // inGameScreen.gameObject.SetActive(true);
        // gameOverText.gameObject.SetActive(false);

    }

    public void Quit()
    {
        Application.Quit();

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseScreen.activeInHierarchy && IsGameActive())
                PauseGame(false);
            else    
                PauseGame(true);

        }
    }
    
    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void ExitGame()
    {
        // titleScreen.gameObject.SetActive(true);
        // inGameScreen.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    // public void RestartGame()
    // {
    //     titleScreen.gameObject.SetActive(false);
    //     inGameScreen.gameObject.SetActive(true);
    // }
}
