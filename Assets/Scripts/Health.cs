using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health
{
    private float currentHealth;
    private float maxHealth;
    private float healthRegenRate;

    public Action<float> OnHealthUpdate;

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

        OnHealthUpdate?.Invoke(currentHealth);
    }
    // Bugged
    public void AddHealth(float value)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + value);
        OnHealthUpdate?.Invoke(currentHealth);
    }
    // Bugged
    public void DeductHealth(float value)
    {
        currentHealth = Mathf.Max(0, currentHealth - value);
        OnHealthUpdate?.Invoke(currentHealth);
    }

    public void RegenHealth()
    {
        AddHealth(healthRegenRate * Time.deltaTime);
    }
}
