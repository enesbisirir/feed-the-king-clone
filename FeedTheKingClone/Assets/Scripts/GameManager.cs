using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CakeSpawner cakeSpawner;

    void Start()
    {
        cakeSpawner.Spawn();
        CakeCollection.CurrentCake.Fell += cakeSpawner.Spawn;
        CakeCollection.Cakes.Changed += OnCakesChanged;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CakeCollection.CurrentCake.Fall();
        }
    }

    private void OnCakesChanged()
    {
        CakeCollection.CurrentCake.Fell += cakeSpawner.Spawn;
    }
}
