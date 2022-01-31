using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ICollidable
{
    public float TopLeftCorner();
    public float TopRightCorner();
    public float BottomLeftCorner();
    public float BottomRightCorner();
}
