using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI timeTakenText;
    private float timeElapsed=0f;
    void Start()
    {
        timerText.text = "  TIME ELAPSED: <color=#00BF63>{0:00}:{1:00}" + timeElapsed;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    void Update()
    {
        if(gameManager.IsGameActive())
        {
            // if (timeRemaining > 0)
            // {

                timeElapsed += UnityEngine.Time.deltaTime;
                // timerText.text = "  TIME ELAPSED: " + DisplayTime(timeElapsed);
                DisplayTime(timeElapsed);
                DisplayTimeTaken(timeElapsed);
                // timeTakenText.text = "TIME TAKEN:  color=#00BF63>{0:00}:{1:00}" + timeElapsed;

            // }

            // if(timeElapsed<=0)
            // {
                // gameManager.DisplayGameOver();
            // }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay+=1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("  TIME ELAPSED: <color=#00BF63>{0:00}:{1:00}", minutes, seconds);
    }

    void DisplayTimeTaken(float timeToDisplay)
    {
        timeToDisplay+=1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeTakenText.text = string.Format("TIME TAKEN:  <color=#00BF63>{0:00}:{1:00}", minutes, seconds);
    }
}
