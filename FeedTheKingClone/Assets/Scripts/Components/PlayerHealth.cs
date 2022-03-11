using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth
{
    private int health;

    public Action HealthDecreased {get; private set;}
    public Action Dead {get; private set;}

    public PlayerHealth()
    {
        health = 3;
    }

    public void DecreaseHealth()
    {
        health -= 1;

        if (health > 0)
        {
            Debug.Log($"Current health: {health}");
            HealthDecreased?.Invoke();
        }
        else if (health == 0) 
        {
            Debug.Log("Dead");
            Dead?.Invoke();
        }
        else 
        {
            Debug.LogWarning("Health cannot be below 0");
        }
    }

    public int GetCurrentHealth() => health;
}
