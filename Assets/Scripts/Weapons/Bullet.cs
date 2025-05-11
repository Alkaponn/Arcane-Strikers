using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] string targetTag;

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject hitObject = collision.gameObject;

        if (hitObject.CompareTag(targetTag)) {
            DealDamage(hitObject);
        }
    }

    void DealDamage(GameObject target) {
        Health health = target.GetComponent<Health>();

        if (health != null) {
            health.TakeDamage(damage);
            ApplyAfterHitEffect();
        }
    }

    void ApplyAfterHitEffect() {
        Destroy(gameObject);
    }
}
