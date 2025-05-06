using UnityEngine;

public class DefaultStaff : Staff
{
    [SerializeField] Camera mainCamera;

    protected override void CalculateTargetPosition() {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        targetPosition = (Vector2)mousePos;
    }

    protected override void Shoot(GameObject bullet) {
        Vector2 bulletDirection = (targetPosition - (Vector2) bullet.transform.position).normalized;
        Vector2 bulletVelocity = bulletSpeed * bulletDirection;
        Rigidbody2D staffBulletRb = bullet.GetComponent<Rigidbody2D>();
        staffBulletRb.linearVelocity = bulletVelocity;
        
        Destroy(bullet, bulletLifetime);
    }
}
