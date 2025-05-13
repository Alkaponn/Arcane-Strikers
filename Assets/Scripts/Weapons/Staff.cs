using UnityEngine;

public abstract class Staff : MonoBehaviour
{
    [SerializeField] protected GameObject staffBulletPrefab;
    [SerializeField] protected Vector2 bulletOffsetFromStaff;
    [SerializeField] protected float bulletCooldown;
    [SerializeField] protected float bulletLifetime;

    protected float bulletTimer;
    private GameObject bulletsParent;

    protected virtual void Start()
    {
        bulletTimer = 0f;
        bulletsParent = GameObject.FindGameObjectWithTag("BulletsParent");
    }

    void Update()
    {
        if (bulletTimer >= bulletCooldown) {
            bulletTimer = 0f;
            GameObject bullet = SpawnBullet();
            Vector2 velocity = CalculateBulletVelocity(bullet);
            Shoot(bullet, velocity);
        }
        else {
            bulletTimer += Time.deltaTime;
        }
    }

    GameObject SpawnBullet() {
        Vector2 bulletSpawnPosition = new Vector2(transform.position.x, transform.position.y) + bulletOffsetFromStaff;
        GameObject bullet = Instantiate(staffBulletPrefab, bulletSpawnPosition, Quaternion.identity, bulletsParent.transform);
        bullet.GetComponent<Bullet>().bulletPrefab = staffBulletPrefab;
        return bullet;
    }

    public void DivideBulletCooldownByFactor(float factor) {
        bulletCooldown /= factor;
    }

    Vector2 CalculateBulletVelocity(GameObject bullet){
        Vector2 targetPosition = CalculateTargetPosition();
        Vector2 bulletDirection = (targetPosition - (Vector2) bullet.transform.position).normalized;
        Vector2 bulletVelocity = bullet.GetComponent<Bullet>().bulletSpeed * bulletDirection;

        return bulletVelocity;
    }

    protected virtual void Shoot(GameObject bullet, Vector2 velocity) {
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = velocity;

        Destroy(bullet, bulletLifetime);
    }

    protected abstract Vector2 CalculateTargetPosition();
}
