using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthStatusController : MonoBehaviour
{
    [SerializeField]
    float maxHealth = 100.0F;

    [SerializeField]
    Slider healthBar;

    [SerializeField]
    GameObject DeathUI;

    float currentHealth;

    [HideInInspector]
   public UnityEvent<float> onHealthChanged;
    [HideInInspector]
    public UnityEvent onDie;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;

    }

    public void Damage(float value) {
        currentHealth -= value;
        onHealthChanged?.Invoke(currentHealth);
        if (currentHealth <= 0.0) {
            currentHealth = 0.0F;
            onDie.Invoke();
            DeathUI.SetActive(true);
        }
        healthBar.value = currentHealth;
    }

    public void Heal(int value) 
    {
        currentHealth += value;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        onHealthChanged?.Invoke(currentHealth);
        healthBar.value = currentHealth;
    }
}


