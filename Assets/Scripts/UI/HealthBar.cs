using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Health playerHealth;
    private Slider slider;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        SetFill();
    }

    void SetFill() {
        slider.value = playerHealth.GetCurrentHealthPoint() / playerHealth.GetMaxHealthPoint();
    }
}
