using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Health targetHealth;
    public Slider slider;

    void Start()
    {
        slider.maxValue = targetHealth.MaxHP;
        slider.value = targetHealth.CurrentHP;
    }

    void Update()
    {
        slider.value = targetHealth.CurrentHP;
    }
}
