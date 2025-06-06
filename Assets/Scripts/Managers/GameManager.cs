using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] MainCharacterHealth mainCharacterHealth;
    [SerializeField] DeathScreen deathScreen;
    [SerializeField] HUD hud;
    [SerializeField] Menu menu;
    [SerializeField] GameObject pauseMenu;

    void Awake()
    {
        PauseGame();
    }

    void Start()
    {
        mainCharacterHealth.OnPlayerDeath += PlayerAfterDeathEffects;
    }

    void PlayerAfterDeathEffects() {
        deathScreen.gameObject.SetActive(true);
        deathScreen.Display(scoreManager.GetTime(), scoreManager.GetScoreText());
        hud.Disappear();
        SaveHighScore();
        PauseGame();
    }

    void PauseGame() {
        Time.timeScale = 0f;
    }

    void UnpauseGame() {
        Time.timeScale = 1f;
    }

    public void RestartGame() {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void StartGame() {
        menu.Disappear();
        hud.Display();
        UnpauseGame();
    }

    public void TogglePauseMenu() {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        
        if (pauseMenu.activeSelf) {
            PauseGame();
        }
        else {
            UnpauseGame();
        }
    }

    public void Quit() {
        Application.Quit();
    }

    public void SaveHighScore() {
        int score = scoreManager.GetScore();

        int currentHigh = PlayerPrefs.GetInt("HighScore", 0);
        if (score > currentHigh)
        {
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.Save();
        }
    }
}
