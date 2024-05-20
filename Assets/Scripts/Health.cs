using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float currentHealth;
    private float maxHealth;
    private float healthRegenRate;

    public float GetHealth()
    {
        return currentHealth;
    }

    public Health() { }

    public Health(float maxHealth, float healthRegenRate, float currentHealth = 100)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        this.healthRegenRate = healthRegenRate;
    }
    // Bugged
    public void AddHealth(float value)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + value);
    }
    // Bugged
    public void DeductHealth(float value)
    {
        currentHealth = Mathf.Max(0, currentHealth - value);
    }

    public void RegenHealth()
    {
        AddHealth(healthRegenRate * Time.deltaTime);
    }
}
