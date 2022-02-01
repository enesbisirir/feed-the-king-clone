using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CakeSpawner cakeSpawner;
    [SerializeField] private Tray tray;

    void Start()
    {
        cakeSpawner.Spawn();
        Cake.Fallen += OnFallen;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsFallLegal())
            {
                CakeCollection.Cakes.CurrentCake().FreeFall();
                CakeCollection.Cakes.CurrentCake().Destroyy();
                cakeSpawner.Spawn();

            }
            else
            {
                CakeCollection.Cakes.CurrentCake().Fall();
            }
        }

    }

    private void OnFallen()
    {
        CakeCollection.Cakes.CurrentCake().Stop();
        cakeSpawner.Spawn();
    }

    private bool IsFallLegal()
    {
        ICollidable fallingObject = CakeCollection.Cakes.CurrentCake();
        ICollidable stationaryObject = CakeCollection.Cakes.PreviousCake() ? CakeCollection.Cakes.PreviousCake() : (ICollidable)tray;

        if (fallingObject.BottomLeftCorner() > stationaryObject.TopRightCorner() ||
            fallingObject.BottomRightCorner() < stationaryObject.TopLeftCorner())
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
