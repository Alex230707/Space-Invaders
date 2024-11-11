using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    
    public int PlayerScore;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI NumHighScoreText;

    private void Start()
    {   
        NumHighScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

    }

    public void AddScore(int ScoretoAdd)
    {
        PlayerScore += ScoretoAdd;
        NumHighScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        if (PlayerScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", PlayerScore);
            NumHighScoreText.text = PlayerScore.ToString();
        }

        ScoreText.text = PlayerScore.ToString();
    }



}