using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public event Action<EnemyType> OnEnemyDeath;

    public void InvokeOnEnemyDeath(EnemyType enemyType) {
        OnEnemyDeath?.Invoke(enemyType);
    }
}
