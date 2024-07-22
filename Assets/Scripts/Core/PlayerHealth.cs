using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    [SerializeField]
    private Slider healthSlider;

    private int currentHealth;

    private void Awake()
    {
        Instance = this;
    }

    public void SetHealthBar(int health)
    {
        currentHealth = health;
        healthSlider.maxValue = health;
        healthSlider.value = health;
    }

    private void UpdateHealthBarValue(int currentHealth)
    {
        healthSlider.value = currentHealth;
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("You lose!");
        }
        
        UpdateHealthBarValue(currentHealth);
    }
}
