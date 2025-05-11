using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] EnemyManager enemyManager;

    protected override void ApplyAfterDeathEffect()
    {

        enemyManager.InvokeOnEnemyDeath(GetComponent<EnemyTypeContainer>().enemyType);
        Destroy(gameObject);
    }
}
