using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour, ICollidable
{
    [SerializeField] private GameObject topLeftCorner;
    [SerializeField] private GameObject topRightCorner;
    [SerializeField] private GameObject bottomLeftCorner;
    [SerializeField] private GameObject bottomRightCorner;

    public float TopLeftCorner() => topLeftCorner.transform.position.x;

    public float TopRightCorner() => topRightCorner.transform.position.x;

    public float BottomLeftCorner() => bottomLeftCorner.transform.position.x;

    public float BottomRightCorner() => bottomRightCorner.transform.position.x;
}
