using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private string scoreTextFormat;
    private int score;

    void Start()
    {
        scoreText = transform.Find("ValuePart").Find("ValueText").GetComponent<TextMeshProUGUI>();
        scoreTextFormat = "{0:00000}";
        score = 0;
    }

    void Update()
    {
        if (Time.timeScale == 0f) {
            return;
        }
        
        SetScoreText();
    }

    void SetScoreText() {
        scoreText.text = string.Format(scoreTextFormat, score);
    }

    public void AddScore(int value) {
        score += value;
    }

    public string GetScore() {
        return scoreText.text;
    }
}
