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
        if (Time.timeScale == 0f) {
            return;
        }
        
        UseStaff();
    }

    protected virtual void UseStaff() {
        if (bulletTimer >= bulletCooldown) {
            bulletTimer = 0f;
            GameObject bullet = SpawnBullet();
            Vector2 targetPosition = CalculateTargetPosition();
            Vector2 velocity = CalculateBulletVelocity(bullet, targetPosition);
            Shoot(bullet, velocity);
        }
        else {
            bulletTimer += Time.deltaTime;
        }
    }

    protected GameObject SpawnBullet() {
        Vector2 bulletSpawnPosition = new Vector2(transform.position.x, transform.position.y) + bulletOffsetFromStaff;
        GameObject bullet = Instantiate(staffBulletPrefab, bulletSpawnPosition, Quaternion.identity, bulletsParent.transform);
        bullet.GetComponent<Bullet>().bulletPrefab = staffBulletPrefab;
        return bullet;
    }

    public void DivideBulletCooldownByFactor(float factor) {
        bulletCooldown /= factor;
    }

    protected virtual Vector2 CalculateBulletVelocity(GameObject bullet, Vector2 targetPosition){
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
