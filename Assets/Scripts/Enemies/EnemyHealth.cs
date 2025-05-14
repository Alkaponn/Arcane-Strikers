using System;
using UnityEngine;

public class EnemyHealth : Health
{
    public event Action<GameObject> OnEnemyDeath;

    private ScoreManager scoreManager;
    private WaveManager waveManager;
    private DropManager dropManager;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        waveManager = GameObject.FindGameObjectWithTag("EnemiesParent").GetComponent<WaveManager>();
        dropManager = GameObject.FindGameObjectWithTag("DropManager").GetComponent<DropManager>();

        OnEnemyDeath += scoreManager.AddScoreOnEnemyDeath;
        OnEnemyDeath += waveManager.RemoveEnemyFromWaveOnDeath;
        OnEnemyDeath += dropManager.Drop;
    }

    protected override void ApplyAfterDeathEffect()
    {
        OnEnemyDeath?.Invoke(gameObject);
        Destroy(gameObject);
    }
}
