using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CakeFallState : BaseState
{
    private CakeSpawner cakeSpawner;
    private Tray tray;
    private InputHandler inputHandler;
    private King king;
    private PlayerHealth playerHealth;
    private Action<Cake> FallenIllegally {get; set;}

    public CakeFallState(ObjectContainer container)
    {
        cakeSpawner = container.GetComponent("CakeSpawner") as CakeSpawner;
        tray = container.GetComponent("Tray") as Tray;
        inputHandler = container.GetComponent("InputHandler") as InputHandler;
        king = container.GetComponent("King") as King;
        playerHealth = container.GetComponent("PlayerHealth") as PlayerHealth;
    }

    protected override void OnEnter()
    {
        Cake.FallStarted += OnFallStarted;
        Cake.Fallen += OnFallen;
        inputHandler.TouchStarted += OnTouchStarted;
        FallenIllegally += OnFallIllegally;

        cakeSpawner.Spawn();
    }
    protected override void OnUpdate()
    {

    }
    protected override void OnExit()
    {
        Cake.FallStarted -= OnFallStarted;
        Cake.Fallen -= OnFallen;
        inputHandler.TouchStarted -= OnTouchStarted;
        FallenIllegally -= OnFallIllegally;
    }

    private void OnFallStarted(Cake cake)
    {
        ICollidable fallingObject = cake.GetComponent<ICollidable>();

        ICollidable stationaryObject = CakeCollection.Cakes.PreviousCake() ?
                                       CakeCollection.Cakes.PreviousCake().GetComponent<ICollidable>() :
                                       tray.GetComponent<ICollidable>();

        if (!IsFallLegal(fallingObject, stationaryObject))
        {
            FallenIllegally?.Invoke(cake);
        }
    }

    private void OnFallIllegally(Cake cake)
    {
        cake.FreeFall();
        cake.DestroyCake();

        var currentHealth = playerHealth.DecreaseHealth();
        
        if (currentHealth > 0)
            cakeSpawner.Spawn();
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

    private void OnFallen(GameObject fallingObject, GameObject stationaryObject)
    {
        fallingObject.GetComponent<Cake>().Stop();
        cakeSpawner.Spawn();
    }

    private void OnTouchStarted()
    {
        CakeCollection.Cakes.CurrentCake().Fall();
    }
}
