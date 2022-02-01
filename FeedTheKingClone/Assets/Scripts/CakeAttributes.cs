using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cake Attributes")]
public class CakeAttributes : ScriptableObject
{
    [SerializeField] private float fallingSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float illegalFallDestroyDelay;

    public float FallingSpeed { get => fallingSpeed; }
    public float HorizontalSpeed { get => horizontalSpeed; }
    public float IllegalFallDestroyDelay { get => illegalFallDestroyDelay; }
}
