using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    private Animator deathScreenAnimator;
    private Button quitToMenuButton;
    private TextMeshProUGUI timerText;
    private TextMeshProUGUI scoreText;

    void Awake()
    {
        deathScreenAnimator = GetComponent<Animator>();
        quitToMenuButton = transform.Find("Buttons").Find("QuitToMenuButton").GetComponent<Button>();
        timerText = transform.Find("SurvivalTime").GetComponent<TextMeshProUGUI>();
        scoreText = transform.Find("FinalScore").GetComponent<TextMeshProUGUI>();
    }

    public void Display(string timeTextValue, string scoreTextValue) {
        deathScreenAnimator.SetTrigger("deathTrigger");
        quitToMenuButton.interactable = true;
        timerText.text = timeTextValue;
        scoreText.text = scoreTextValue;
    }
}
