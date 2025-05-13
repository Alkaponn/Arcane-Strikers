using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject batPrefab;
    [SerializeField] GameObject skullPrefab;
    [SerializeField] GameObject golemPrefab;
    [SerializeField] GameObject batBossPrefab;
    [SerializeField] GameObject skullBossPrefab;
    [SerializeField] GameObject golemBossPrefab;
    [SerializeField] float secondsBetweenWaves;
    [SerializeField] float bulletRateIncreasePercentage;
    [SerializeField] Vector2 spawnAreaTopRight;
    [SerializeField] Vector2 spawnAreaBottomLeft;
    [SerializeField] List<EnemyType> waveTypeSequence;
    [SerializeField] List<int> waveEnemyCountSequence;

    private float waveTimer;
    private List<GameObject> enemiesInWave;
    private int waveTypeSequenceIndex;
    private int waveEnemyCountSequenceIndex;
    private float bulletRateFactor;

    void Start()
    {
        waveTimer = 0f;
        waveTypeSequenceIndex = 0;
        waveEnemyCountSequenceIndex = 0;
        bulletRateFactor = 1f;

        enemiesInWave = new List<GameObject>();
    }

    void Update()
    {
        if (IsWaveCleared()) {
            waveTimer += Time.deltaTime;

            if (waveTimer >= secondsBetweenWaves) {
                waveTimer = 0f;
                SpawnNextWave();
                IncrementIndices();
            }
        }
    }

    public void RemoveEnemyFromWaveOnDeath(GameObject gameObject) {
        enemiesInWave.Remove(gameObject);
    }

    void SpawnNextWave() {
        EnemyType waveType = waveTypeSequence[waveTypeSequenceIndex];
        int enemyCount = waveEnemyCountSequence[waveEnemyCountSequenceIndex];
        GameObject enemyPrefab;
        print(waveTypeSequenceIndex);

        switch (waveType) {
            case EnemyType.BAT:
                enemyPrefab = batPrefab;
                break;
            case EnemyType.BATBOSS:
                enemyPrefab = batBossPrefab;
                break;
            case EnemyType.SKULL:
                enemyPrefab = skullPrefab;
                break;
            case EnemyType.SKULLBOSS:
                enemyPrefab = skullBossPrefab;
                break;
            case EnemyType.GOLEM:
                enemyPrefab = golemPrefab;
                break;
            case EnemyType.GOLEMBOSS:
                enemyPrefab = golemBossPrefab;
                break;
            default:
                enemyPrefab = batPrefab;
                break;
        }

        SpawnEnemies(enemyCount, enemyPrefab);
    }

    void SpawnEnemies(int count, GameObject enemyPrefab) {
        for (int i = 0; i < count; i++) {
            Vector2 spawnPosition = GetRandomSpawnPosition();
            GameObject enemyGameObject = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemyGameObject.GetComponentInChildren<EnemyStaff>().DivideBulletCooldownByFactor(bulletRateFactor);
            enemiesInWave.Add(enemyGameObject);
        }
    }

    Vector2 GetRandomSpawnPosition() {
        float spawnX = Random.Range(spawnAreaBottomLeft.x, spawnAreaTopRight.x);
        float spawnY = Random.Range(spawnAreaBottomLeft.y, spawnAreaTopRight.y);

        return new Vector2(spawnX, spawnY);
    }

    bool IsWaveCleared() {
        return enemiesInWave.Count == 0;
    }

    void IncrementIndices() {
        waveEnemyCountSequenceIndex = (waveEnemyCountSequenceIndex + 1) % waveEnemyCountSequence.Count;

        waveTypeSequenceIndex++;

        if (waveTypeSequenceIndex == waveTypeSequence.Count) {
            waveTypeSequenceIndex = 0;
            bulletRateFactor += (bulletRateIncreasePercentage / 100);
        }
    }
}
