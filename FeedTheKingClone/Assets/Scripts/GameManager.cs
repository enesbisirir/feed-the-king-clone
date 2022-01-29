using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CakeSpawner cakeSpawner;

    void Start()
    {
        cakeSpawner.Spawn();
        CakeCollection.CurrentCake.OnFell += cakeSpawner.Spawn;
        CakeCollection.Cakes.Changed += OnCakesChanged;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CakeCollection.CurrentCake.Fall();
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Current cake: " + CakeCollection.CurrentCake.name);
            //Debug.Log("Previous cake: " + CakeCollection.Cakes.GetPreviousCake().name);
        }
    }

    private void OnCakesChanged()
    {
        CakeCollection.CurrentCake.OnFell += cakeSpawner.Spawn;
    }
}
