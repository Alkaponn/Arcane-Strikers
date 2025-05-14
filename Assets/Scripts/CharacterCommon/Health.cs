using UnityEngine;

public abstract class Health : MonoBehaviour
{
    [SerializeField] float maxHealthPoint;

    private float currentHealthPoint;

    void Awake()
    {
        currentHealthPoint = maxHealthPoint;
    }
    
    bool IsDead() {
        return currentHealthPoint <= 0;
    }

    public virtual void TakeDamage(float damage) {
        if (IsDead()) {
            return;
        }

        currentHealthPoint -= damage;
        currentHealthPoint = (currentHealthPoint < 0) ? 0 : currentHealthPoint;

        if (IsDead()) {
            ApplyAfterDeathEffect();
        }
    }

    public float GetMaxHealthPoint() {
        return maxHealthPoint;
    }

    public float GetCurrentHealthPoint() {
        return currentHealthPoint;
    }

    protected abstract void ApplyAfterDeathEffect();
}
