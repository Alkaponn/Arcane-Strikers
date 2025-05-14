using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    private Animator menuAnimator;
    private Button playButton;
    private Button quitButton;
    private TextMeshProUGUI bestScore;
    private string bestScoreFormat;

    void Start()
    {
        menuAnimator = GetComponent<Animator>();
        playButton = transform.Find("PlayPart").Find("PlayButton").GetComponent<Button>();
        quitButton = transform.Find("QuitPart").Find("QuitButton").GetComponent<Button>();
        bestScore = transform.Find("BestScore").GetComponent<TextMeshProUGUI>();
        bestScoreFormat = "Best Score: {0:00000}";

        DisplayBestScore();
    }

    void DisplayBestScore() {
        int highScore = 0;

        if (PlayerPrefs.HasKey("HighScore")) {
            highScore = PlayerPrefs.GetInt("HighScore", 0);
        }
        else {
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        bestScore.text = string.Format(bestScoreFormat, highScore);
    }

    public void Disappear() {
        menuAnimator.SetTrigger("startGameTrigger");
        playButton.interactable = false;
        quitButton.interactable = false;
    }
}
