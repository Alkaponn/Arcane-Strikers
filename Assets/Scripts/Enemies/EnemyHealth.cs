using System;
using UnityEngine;

public class EnemyHealth : Health
{
    public event Action<GameObject> OnEnemyDeath;

    private ScoreManager scoreManager;
    private WaveManager waveManager;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        waveManager = GameObject.FindGameObjectWithTag("EnemiesParent").GetComponent<WaveManager>();

        OnEnemyDeath += scoreManager.AddScoreOnEnemyDeath;
        OnEnemyDeath += waveManager.RemoveEnemyFromWaveOnDeath;
    }

    protected override void ApplyAfterDeathEffect()
    {
        OnEnemyDeath?.Invoke(gameObject);
        Destroy(gameObject);
    }
}
