using System;
using UnityEngine;

public class HealthSystem
{
    private float health;
    private float maxHealth;

    public Action OnDied;

    public HealthSystem(float maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public void IncreaseHealth(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
    }

    public void DecreaseHealth(float amount)
    {
        health -= amount;
        Debug.Log("health: " + health);
        if (health <= 0)
        {
            OnDied?.Invoke();
        }
        health = Mathf.Clamp(health, 0, maxHealth);
    }
}
