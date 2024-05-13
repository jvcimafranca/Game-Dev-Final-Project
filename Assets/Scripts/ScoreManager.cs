using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
   private int score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI orbsCollectedText;
    void Start()
    {
        score = 0;
        scoreText.text = "  ORBS COLLECTED: " + "<color=#00BF63>" + score + "</color>";
        // finalScoreText.text = "FINAL SCORE: " + score;
    }

   public void UpdateScore(int score)
   {
    this.score += score;
    scoreText.text = "  ORBS COLLECTED: " + "<color=#00BF63>" + this.score + "</color>";
    orbsCollectedText.text = "TOTAL ORBS COLLECTED:   " + "<color=#00BF63>" + this.score + "</color>";
   }
}
