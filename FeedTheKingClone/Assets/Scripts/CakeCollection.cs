using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeCollection
{
    private List<Cake> cakes = new List<Cake>();

    public static CakeCollection Cakes = new CakeCollection();

    public void Add(Cake cake)
    {
        cakes.Add(cake);
    }

    public void Remove(Cake cake)
    {
        cakes.Remove(cake);
    }

    public Cake CurrentCake() => cakes[cakes.Count - 1];

    public Cake PreviousCake() => cakes.Count >= 2 ? cakes[cakes.Count - 2] : null;
}
