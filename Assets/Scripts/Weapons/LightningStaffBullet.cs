using System;
using System.Collections.Generic;
using UnityEngine;

public class LightningStaffBullet : Bullet
{
    [SerializeField] public int maxHops;

    private GameObject bulletsParent;
    private WaveManager waveManager;

    void Start()
    {
        bulletsParent = GameObject.FindGameObjectWithTag("BulletsParent");
        waveManager = GameObject.FindGameObjectWithTag("EnemiesParent").GetComponent<WaveManager>();
    }

    protected override void ApplyAfterHitEffect(GameObject target)
    {
        if (maxHops > 0) {
            Vector2 closestEnemyPosition = GetClosestEnemyPosition(target);
            Vector2 velocityUnitVector = (closestEnemyPosition - (Vector2) transform.position).normalized;
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, bulletsParent.transform);
            bullet.GetComponent<LightningStaffBullet>().maxHops--;
            Rigidbody2D bulletRb= bullet.GetComponent<Rigidbody2D>();
            bulletRb.linearVelocity = bulletSpeed * velocityUnitVector;
        }

        base.ApplyAfterHitEffect(target);
    }

    Vector2 GetClosestEnemyPosition(GameObject target) {
        List<GameObject> enemies = waveManager.enemiesInWave;
        float minDistance = float.MaxValue;
        Vector2 enemyPosition = target.transform.position;

        foreach (GameObject enemy in enemies) {
            if (!enemy.Equals(target)) {
                float distance = GetDistanceBetweenEnemies(target, enemy);

                if (distance < minDistance) {
                    minDistance = distance;
                    enemyPosition = enemy.transform.position;
                }
            }
        }

        return enemyPosition;
    }

    float GetDistanceBetweenEnemies(GameObject enemy1, GameObject enemy2) {
        return (enemy1.transform.position - enemy2.transform.position).magnitude;
    }
}
