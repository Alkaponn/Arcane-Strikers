using System;
using UnityEngine;

public class WaterStaffBullet : Bullet
{
    [SerializeField] int splashCount;
    [SerializeField] float splashLifeTime;
    [SerializeField] float splashRadius;

    public bool isSplash = false;

    private GameObject bulletsParent;

    void Start()
    {
        bulletsParent = GameObject.FindGameObjectWithTag("BulletsParent");
    }

    protected override void ApplyAfterHitEffect(GameObject target)
    {
        if (!isSplash) {
            for (int i = 0; i < splashCount; i++) {
                Vector2 velocityUnitVector = new Vector2((float) Math.Cos(i * (Math.PI / 4)), (float) Math.Sin(i * (Math.PI / 4))); 
                Vector2 splashPosition = (Vector2) transform.position + (splashRadius * velocityUnitVector);
                GameObject splashBullet = Instantiate(bulletPrefab, splashPosition, Quaternion.identity, bulletsParent.transform);
                Rigidbody2D splashBulletRb = splashBullet.GetComponent<Rigidbody2D>();
                splashBulletRb.linearVelocity = bulletSpeed * velocityUnitVector;
                splashBullet.GetComponent<WaterStaffBullet>().damage /= splashCount;
                splashBullet.GetComponent<WaterStaffBullet>().isSplash = true;
                splashBullet.transform.localScale /= 2;

                Destroy(splashBullet, splashLifeTime);
            }
        }

        base.ApplyAfterHitEffect(target);
    }
}
