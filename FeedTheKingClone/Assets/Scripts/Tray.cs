using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour, ICollidable
{
    [SerializeField] private GameObject topLeftCorner;
    [SerializeField] private GameObject topRightCorner;
    [SerializeField] private GameObject bottomLeftCorner;
    [SerializeField] private GameObject bottomRightCorner;

    public float TopLeftCorner()
    {
        return topLeftCorner.transform.position.x;
    }

    public float TopRightCorner()
    {
        return topRightCorner.transform.position.x;
    }

    public float BottomLeftCorner()
    {
        return bottomLeftCorner.transform.position.x;
    }

    public float BottomRightCorner()
    {
        return bottomRightCorner.transform.position.x;
    }
}
