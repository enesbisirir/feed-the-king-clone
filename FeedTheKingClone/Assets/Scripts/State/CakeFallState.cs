using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeFallState : BaseState
{
    private CakeSpawner cakeSpawner;
    private Tray tray;
    private InputHandler inputHandler;
    private King king;

    public CakeFallState(ObjectContainer container)
    {
        cakeSpawner = container.GetComponent("CakeSpawner") as CakeSpawner;
        tray = container.GetComponent("Tray") as Tray;
        inputHandler = container.GetComponent("InputHandler") as InputHandler;
        king = container.GetComponent("King") as King;
    }

    protected override void OnEnter()
    {
        Cake.FallStarted += OnFallStarted;
        Cake.Fallen += OnFallen;
        inputHandler.TouchStarted += OnTouchStarted;

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
