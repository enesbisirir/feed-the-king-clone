using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CakeSpawner cakeSpawner;

    void Start()
    {
        cakeSpawner.Spawn();
        CakeCollection.Cakes.CurrentCake().Fallen += OnFallen;
        CakeCollection.Cakes.Changed += OnCakesChanged;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CakeCollection.Cakes.CurrentCake().Fall();
        }
    }

    private void OnFallen()
    {
        cakeSpawner.Spawn();
    }

    private void OnCakesChanged()
    {
        CakeCollection.Cakes.CurrentCake().Fallen += cakeSpawner.Spawn;
    }
}
