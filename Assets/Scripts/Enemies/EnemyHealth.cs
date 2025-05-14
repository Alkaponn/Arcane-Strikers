using System;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] float deathDelay;

    public event Action<GameObject> OnEnemyDeath;

    private ScoreManager scoreManager;
    private WaveManager waveManager;
    private DropManager dropManager;
    private Animator animator;
    private EnemyMovement enemyMovement;

    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        waveManager = GameObject.FindGameObjectWithTag("EnemiesParent").GetComponent<WaveManager>();
        dropManager = GameObject.FindGameObjectWithTag("DropManager").GetComponent<DropManager>();
        enemyMovement = GetComponent<EnemyMovement>();

        OnEnemyDeath += scoreManager.AddScoreOnEnemyDeath;
        OnEnemyDeath += waveManager.RemoveEnemyFromWaveOnDeath;
        OnEnemyDeath += dropManager.Drop;
        OnEnemyDeath += enemyMovement.SetIsFrozen;

        animator = GetComponentInParent<Animator>();
    }

    protected override void ApplyAfterDeathEffect()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        OnEnemyDeath?.Invoke(gameObject);
        animator.SetTrigger("die");
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
        Destroy(gameObject, deathDelay);
    }

    public override void TakeDamage(float damage) {
        animator.SetTrigger("hit");
        base.TakeDamage(damage);
    }
}
