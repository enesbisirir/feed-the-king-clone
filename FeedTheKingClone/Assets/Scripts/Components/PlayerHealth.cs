using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth
{
    private int health;

    public Action<int> HealthDecreased {get; internal set;}
    //public Action Dead {get; internal set;}

    public PlayerHealth()
    {
        health = 3;
    }

    public int DecreaseHealth()
    {
        health -= 1;

        if (health >= 0)
        {
            Debug.Log($"Current health: {health}");
            HealthDecreased?.Invoke(health);
        }
        //else if (health == 0) 
        //{
        //    Debug.Log("Dead");
        //    Dead?.Invoke();
        //}
        else 
        {
            Debug.LogWarning("Health cannot be below 0");
        }

        return health;
    }

    public int GetCurrentHealth() => health;
}
