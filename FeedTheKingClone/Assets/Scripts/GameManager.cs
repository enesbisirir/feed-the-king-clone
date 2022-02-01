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
            ICollidable fallingObject = CakeCollection.Cakes.CurrentCake();
            ICollidable stationaryObject = CakeCollection.Cakes.PreviousCake() ? CakeCollection.Cakes.PreviousCake() : (ICollidable)tray;

            bool isLegal = IsFallLegal(fallingObject, stationaryObject);

            CakeCollection.Cakes.CurrentCake().Fall();
        }

    }

    private void OnFallen()
    {
        cakeSpawner.Spawn();
    }

    private bool IsFallLegal(ICollidable fallingItem, ICollidable stationaryItem)
    {
        if (fallingItem.BottomLeftCorner() > stationaryItem.TopRightCorner() ||
            fallingItem.BottomRightCorner() < stationaryItem.TopLeftCorner())
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
