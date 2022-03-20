using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPositioner : MonoBehaviour
{
    [SerializeField] private List<GameObject> walls;

    private ObjectContainer container;
    private GameFieldCalculator gameFieldCalculator;

    private float gameFieldEdgeX;

    private void Start()
    {
        container = FindObjectOfType<ObjectContainer>();
        gameFieldCalculator = container.GetComponent("GameFieldCalculator") as GameFieldCalculator;

        gameFieldEdgeX = gameFieldCalculator.GameFieldEdgeX;

        SetWallPositions();
    }

    private void SetWallPositions()
    {
        var leftWallPosition = new Vector3(-gameFieldEdgeX,
                                           transform.position.y,
                                           transform.position.z);

        var rightWallPosition = new Vector3(gameFieldEdgeX,
                                            transform.position.y,
                                            transform.position.z);

        walls[0].transform.position = leftWallPosition;
        walls[1].transform.position = rightWallPosition;
    }
}
