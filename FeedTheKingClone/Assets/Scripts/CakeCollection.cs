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

    public void Add(Cake cake)
    {
        cakes.Add(cake);

        if (currentCake != null)
        {
            previousCake = currentCake;
        }
        currentCake = cake;
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
