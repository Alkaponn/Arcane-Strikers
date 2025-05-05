using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealthPoint;

    private float currentHealthPoint;

    void Start()
    {
        currentHealthPoint = maxHealthPoint;
    }

    void Update()
    {
        if (IsDead()) {
            Destroy(gameObject);
        }
    }

    bool IsDead() {
        return currentHealthPoint <= 0;
    }

    public void TakeDamage(float damage) {
        currentHealthPoint -= damage;
        currentHealthPoint = (currentHealthPoint < 0) ? 0 : currentHealthPoint;
    }
}
