using UnityEngine;

public abstract class Staff : MonoBehaviour
{
    [SerializeField] GameObject bulletsParent;
    [SerializeField] protected GameObject staffBulletPrefab;
    [SerializeField] protected Vector2 bulletOffsetFromStaff;
    [SerializeField] protected float bulletCooldown;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected float bulletLifetime;

    protected float bulletTimer;
    protected Vector2 targetPosition;

    protected virtual void Start()
    {
        bulletTimer = 0f;
    }

    void Update()
    {
        if (bulletTimer >= bulletCooldown) {
            bulletTimer = 0f;
            CalculateTargetPosition();
            GameObject bullet = SpawnBullet();
            Shoot(bullet);
        }
        else {
            bulletTimer += Time.deltaTime;
        }
    }

    GameObject SpawnBullet() {
        Vector2 bulletSpawnPosition = new Vector2(transform.position.x, transform.position.y) + bulletOffsetFromStaff;
        return Instantiate(staffBulletPrefab, bulletSpawnPosition, Quaternion.identity, bulletsParent.transform);
    }

    protected abstract void CalculateTargetPosition();

    protected abstract void Shoot(GameObject bullet);
}
