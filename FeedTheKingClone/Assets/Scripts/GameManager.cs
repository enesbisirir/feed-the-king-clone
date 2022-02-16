using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CakeSpawner cakeSpawner;
    [SerializeField] private Tray tray;
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private GameState gameState; // SerializeField for testing purposes
    
    void OnEnable()
    {
        Cake.FallStarted += OnFallStarted;
        Cake.Fallen += OnFallen;
        inputHandler.TouchStarted += OnTouchStarted;
    }

    void Start()
    {
        cakeSpawner.Spawn();
    }

    private void OnFallStarted(Cake cake)
    {
        ICollidable stationaryObject = CakeCollection.Cakes.PreviousCake() ? 
                                       CakeCollection.Cakes.PreviousCake().GetComponent<ICollidable>() : 
                                       tray.GetComponent<ICollidable>();

        if (!IsFallLegal(cake.GetComponent<ICollidable>(), stationaryObject))
        {
            cake.FreeFall();
            cake.DestroyCake();

            cakeSpawner.Spawn();
        }
    }

    private void OnFallen(GameObject fallingObject, GameObject stationaryObject)
    {
        fallingObject.GetComponent<Cake>().Stop();
        cakeSpawner.Spawn();
    }

    private void OnTouchStarted()
    {
        CakeCollection.Cakes.CurrentCake().Fall();
    }

    private bool IsFallLegal(ICollidable fallingObject, ICollidable stationaryObject)
    {
        if (fallingObject.BottomLeftCorner().transform.position.x > stationaryObject.TopRightCorner().transform.position.x ||
            fallingObject.BottomRightCorner().transform.position.x < stationaryObject.TopLeftCorner().transform.position.x)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void OnDisable()
    {
        Cake.FallStarted -= OnFallStarted;
        Cake.Fallen -= OnFallen;
        inputHandler.TouchStarted -= OnTouchStarted;
    }
}
