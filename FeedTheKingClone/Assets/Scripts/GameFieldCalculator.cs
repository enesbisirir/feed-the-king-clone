using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFieldCalculator
{
    private Camera camera = Camera.main;

    public float GameFieldEdgeX
    {
        get
        {
            Vector3 topRightCorner = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
            Debug.Log(topRightCorner.x);
            return topRightCorner.x;
        }
    }
}
