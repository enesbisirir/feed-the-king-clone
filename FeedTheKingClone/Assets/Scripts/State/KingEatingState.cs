using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KingEatingState : BaseState
{
    private King king;
    private InputHandler inputHandler;
    private bool isKingMoveStarted;
    public static Action<King> KingStateEntered {get; internal set;}
    public KingEatingState(ObjectContainer container)
    {
        king = container.GetComponent("King") as King;
        inputHandler = container.GetComponent("InputHandler") as InputHandler;
    }
    protected override void OnEnter()
    {
        KingStateEntered?.Invoke(king);
        inputHandler.TouchStarted += OnTouchStarted;
    }
    protected override void OnUpdate()
    {
        if (isKingMoveStarted)
        {
            king.FollowTouch();
            king.Escalate();
        }
    }
    protected override void OnExit()
    {

    }

    private void OnTouchStarted()
    {
        isKingMoveStarted = true;
    }
}
