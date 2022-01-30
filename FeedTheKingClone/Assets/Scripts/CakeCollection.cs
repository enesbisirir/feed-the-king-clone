using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeCollection
{
    private List<Cake> cakes = new List<Cake>();

    public static CakeCollection Cakes = new CakeCollection();

    private Cake currentCake;
    private Cake previousCake;

    public event Action Changed;

    public void Add(Cake cake)
    {
        cakes.Add(cake);

        if (currentCake != null)
        {
            previousCake = currentCake;
        }
        currentCake = cake;

        Changed?.Invoke();
    }

    public Cake CurrentCake()
    {
        return currentCake;
    }

    public Cake PreviousCake()
    {
        return previousCake;
    }
}
