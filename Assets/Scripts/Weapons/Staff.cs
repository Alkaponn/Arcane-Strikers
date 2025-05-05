using UnityEngine;

public class Staff : MonoBehaviour
{
    [SerializeField] GameObject staffBulletPrefab;
    [SerializeField] Camera mainCamera;
    [SerializeField] Vector2 bulletOffsetFromStaff;
    [SerializeField] float bulletCooldown;
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletLifetime;

    private float bulletTimer;

    void Start()
    {
        bulletTimer = 0f;
    }

    void Update()
    {
        if (bulletTimer >= bulletCooldown) {
            bulletTimer = 0f;
            Shoot();
        }
        else {
            bulletTimer += Time.deltaTime;
        }
    }

    void Shoot() {
        Vector2 bulletSpawnPosition = new Vector2(transform.position.x, transform.position.y) + bulletOffsetFromStaff;
        GameObject staffBullet = Instantiate(staffBulletPrefab, bulletSpawnPosition, Quaternion.identity, transform);

        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 bulletDirection = ((Vector2)mousePos - bulletSpawnPosition).normalized;
        Vector2 bulletVelocity = bulletSpeed * bulletDirection;
        Rigidbody2D staffBulletRb = staffBullet.GetComponent<Rigidbody2D>();
        staffBulletRb.linearVelocity = bulletVelocity;
        
        Destroy(staffBullet, bulletLifetime);
    }
}
