using UnityEngine;

public class EnemyStaff : Staff
{
    [SerializeField] float maxDeviation;

    private GameObject player;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override Vector2 CalculateTargetPosition() {
        Vector3 playerPosition = player.transform.position;
        Vector3 bulletSpawnPosition = transform.position + (Vector3) bulletOffsetFromStaff;
        Vector3 distanceVector = playerPosition - bulletSpawnPosition;
        Vector3 deviationUnitVector = Vector3.Cross(distanceVector, new Vector3(0, 0, 1)).normalized;
        float deviation = Random.Range(-maxDeviation, maxDeviation);
        Vector2 targetPosition = (Vector2) (playerPosition + deviation * deviationUnitVector);

        return targetPosition;
    }
}
