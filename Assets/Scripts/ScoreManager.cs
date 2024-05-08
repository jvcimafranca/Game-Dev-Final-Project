using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
   private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    // [SerializeField] private TextMeshProUGUI finalScoreText;
    void Start()
    {
        score = 0;
        scoreText.text = "ORBS COLLECTED: " + score;
        // finalScoreText.text = "FINAL SCORE: " + score;
    }

   public void UpdateScore(int score)
   {
    this.score += score;
    scoreText.text = "ORBS COLLECTED: " + this.score;
    // finalScoreText.text = "FINAL SCORE: " + this.score;
   }
}
