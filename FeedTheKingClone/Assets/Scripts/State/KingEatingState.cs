using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KingEatingState : BaseState
{
    private King king;
    public static Action<King> KingStateEntered {get; internal set;}
    public KingEatingState(ObjectContainer container)
    {
        king = container.GetComponent("King") as King;
    }
    protected override void OnEnter()
    {
        KingStateEntered?.Invoke(king);
    }
    protected override void OnUpdate()
    {

    }
    protected override void OnExit()
    {

    }
}
