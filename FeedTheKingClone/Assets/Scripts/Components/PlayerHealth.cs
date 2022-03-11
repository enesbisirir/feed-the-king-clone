using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth
{
    private int health = 3;

    public int GetHealth() => health;
    public int DecreaseHealth()
    {
        health -= 1;
        return health;
    }
    public int IncreaseHealth()
    {
        health += 1;
        return health;
    }
}
