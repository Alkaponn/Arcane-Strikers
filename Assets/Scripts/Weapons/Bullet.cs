using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage;
    
    private string ownerTag;

    void Start()
    {
        ownerTag = transform.parent.parent.tag;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;

        if (!target.CompareTag(ownerTag)) {
            DealDamage(target);
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
