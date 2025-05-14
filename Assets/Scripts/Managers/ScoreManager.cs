using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] Score score;
    [SerializeField] int scorePerSecond;
    [SerializeField] int scorePerBat;
    [SerializeField] int scorePerSkull;
    [SerializeField] int scorePerGolem;
    
    void Start()
    {
        timer.OnSecondPassed += AddScoreOnSecondPassed;
    }

    public void AddScoreOnSecondPassed() {
        score.AddScore(scorePerSecond);
    }

    public void AddScoreOnEnemyDeath(GameObject enemy) {
        EnemyType enemyType = enemy.GetComponent<EnemyTypeContainer>().enemyType;

        int gainedScore = 0;

        switch (enemyType) {
            case EnemyType.BAT:
                gainedScore = scorePerBat;
                break;
            case EnemyType.SKULL:
                gainedScore = scorePerSkull;
                break;
            case EnemyType.GOLEM:
                gainedScore = scorePerGolem;
                break;
            default:
                gainedScore = 0;
                break;
        }

        score.AddScore(gainedScore);
    }

    public string GetTime() {
        return timer.GetTime();
    }

    public string GetScoreText() {
        return score.GetScoreText();
    }

    public int GetScore() {
        return score.GetScore();
    }
}
