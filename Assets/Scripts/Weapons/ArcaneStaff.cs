using UnityEngine;

public class ArcaneStaff : DefaultStaff
{
    private GameObject arcaneBullet;
    private bool isBulletSpawned = false;

    protected override void UseStaff()
    {
        if (!isBulletSpawned) {
            arcaneBullet = SpawnBullet();
            isBulletSpawned = true;
        }

        Vector2 targetPosition = CalculateTargetPosition();
        Vector2 velocity = CalculateBulletVelocity(arcaneBullet, targetPosition);
        MoveBulletToMousePosition(velocity);
    }

    void MoveBulletToMousePosition(Vector2 velocity) {
        Rigidbody2D arcaneBulletRb = arcaneBullet.GetComponent<Rigidbody2D>();
        arcaneBulletRb.linearVelocity = velocity;
    }

    protected override Vector2 CalculateBulletVelocity(GameObject bullet, Vector2 targetPosition)
    {
        Vector2 bulletVelocity = targetPosition - (Vector2) bullet.transform.position;

        return bullet.GetComponent<Bullet>().bulletSpeed * bulletVelocity;
    }
}
