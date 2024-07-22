using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance { get; private set; }

    [SerializeField]
    private Slider healthSlider;

    private bool missActive;

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
        if (missActive)
        {
            int miss = Random.Range(0, 2);
            
            if (miss == 0 || miss == 2)
            {
                Debug.Log("Miss");
            }
            else
            {
                currentHealth -= damage;

                if (currentHealth <= 0)
                {
                    GameManager.Instance.Lose();
                }
            }
        }
        else
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                GameManager.Instance.Lose();
            }
        }

        UpdateHealthBarValue(currentHealth);
    }

    public void SetMiss(bool miss)
    {
        missActive = miss;
    }
}
