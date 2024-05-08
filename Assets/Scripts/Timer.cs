using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    // [SerializeField] private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI timerText;
    private float timeElapsed=0f;
    void Start()
    {
        timerText.text = "TIME: " + timeElapsed;

    }

    void Update()
    {
        // if(gameManager.IsGameActive())
        // {
            // if (timeRemaining > 0)
            // {
                timeElapsed += UnityEngine.Time.deltaTime;
                timerText.text = "  TIME ELAPSED: " + Mathf.Round(timeElapsed);
            // }

            // if(timeElapsed<=0)
            // {
                // gameManager.DisplayGameOver();
            // }
        // }
    }
}
