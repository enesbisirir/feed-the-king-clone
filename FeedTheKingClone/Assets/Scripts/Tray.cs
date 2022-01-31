using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour, ICollidable
{
    [SerializeField] private GameObject topLeftCorner;
    [SerializeField] private GameObject topRightCorner;
    [SerializeField] private GameObject bottomLeftCorner;
    [SerializeField] private GameObject bottomRightCorner;
}
