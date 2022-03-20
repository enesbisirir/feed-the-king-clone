using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingWaitingToEatState : BaseState
{
    private InputHandler inputHandler;
    private CameraController cameraController;

    public static Action KingWaitingFinished { get; internal set; }

    private bool kingIsReadyToEat = false;

    public KingWaitingToEatState(ObjectContainer container)
    {
        inputHandler = container.GetComponent("InputHandler") as InputHandler;
        cameraController = container.GetComponent("CameraController") as CameraController;
    }

    protected override void OnEnter()
    {
        Debug.Log("King Waiting To Eat State Started");

        inputHandler.TouchStarted += OnTouchStarted;
        cameraController.CameraMovedToKing += OnCameraMovedToKing;

        cameraController.MoveCameraToKing();
    }

    private void OnCameraMovedToKing()
    {
        kingIsReadyToEat = true;
    }

    private void OnTouchStarted()
    {
        if (kingIsReadyToEat)
        {
            KingWaitingFinished?.Invoke();
            Debug.Log("King is ready to eat!");
        }
    }

    protected override void OnExit()
    {
        inputHandler.TouchStarted -= OnTouchStarted;
        cameraController.CameraMovedToKing -= OnCameraMovedToKing;
    }

    protected override void OnUpdate()
    {
    }
}
