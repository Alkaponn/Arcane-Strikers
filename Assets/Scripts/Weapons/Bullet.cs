using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float damage;
    [SerializeField] public float bulletSpeed;
    [SerializeField] string targetTag;

    public GameObject bulletPrefab;

    protected AudioManager audioManager;

    protected virtual void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

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
            ApplyAfterHitEffect(target);
        }
    }

    protected virtual void ApplyAfterHitEffect(GameObject target) {
        if (targetTag.Equals("Enemy")) {
            audioManager.PlayDefaultSound();
        }
        else {
            audioManager.PlayEnemySound();
        }

        Destroy(gameObject);
    }
}
