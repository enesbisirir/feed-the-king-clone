using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        CakeSpawner.Instance.Spawn();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cake.CurrentCake.Stop();
            Cake.CurrentCake.Fall();
        }

    }
}
