using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KingEatingState : BaseState
{
    private King king;
    private CameraController cameraController;

    public KingEatingState(ObjectContainer container)
    {
        king = container.GetComponent("King") as King;
        cameraController = container.GetComponent("CameraController") as CameraController;
    }

    protected override void OnEnter()
    {
        Debug.Log("King Eating State Started");
        king.Escalate();
    }

    protected override void OnUpdate()
    {
        king.FollowTouch();
        cameraController.FollowKing();
    }

    protected override void OnExit()
    {
        king.StopMovement();
    }
}
