using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeCollection
{
    private List<Cake> cakes = new List<Cake>();

    public static CakeCollection Cakes = new CakeCollection();
    public static Cake CurrentCake;

    public event Action Changed;

    public void Add(Cake cake)
    {
        cakes.Add(cake);
        CurrentCake = cake;
        Changed?.Invoke();
    }

    public Cake GetPreviousCake()
    {
        if (cakes.Count <= 1)
        {
            return null;
        }
        else
        {
            return cakes[cakes.Count - 2];
        }
    }
}
