using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour, ICollidable
{
    [SerializeField] private GameObject topLeftCorner;
    [SerializeField] private GameObject topRightCorner;
    [SerializeField] private GameObject bottomLeftCorner;
    [SerializeField] private GameObject bottomRightCorner;

    public GameObject TopLeftCorner() => topLeftCorner;
    public GameObject TopRightCorner() => topRightCorner;
    public GameObject BottomLeftCorner() => bottomLeftCorner;
    public GameObject BottomRightCorner() => bottomRightCorner;
}
