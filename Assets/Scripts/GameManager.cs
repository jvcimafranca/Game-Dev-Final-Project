using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int levelToChange;
    private bool isGameActive=false;
    void Start()
    {
        // titleText.gameObject.SetActive(true);
        // gameOverText.gameObject.SetActive(false);
        // timeScoreText.gameObject.SetActive(false);
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
        // SceneManager.LoadScene(1);
        
    }

    public void StartGame()
    {
        isGameActive =  true;
        SceneManager.LoadScene(2);
        // SceneManager.LoadScene(1);
        // titleText.gameObject.SetActive(false);
        // timeScoreText.gameObject.SetActive(true);
        // gameOverText.gameObject.SetActive(false);

        
        


    }
}
