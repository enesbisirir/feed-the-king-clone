using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ICollidable
{
    public GameObject TopLeftCorner();
    public GameObject TopRightCorner();
    public GameObject BottomLeftCorner();
    public GameObject BottomRightCorner();
}
