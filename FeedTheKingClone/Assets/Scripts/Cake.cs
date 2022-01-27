using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    // TODO: Use scriptable object?
    [SerializeField] private float horizontalSpeed = 1f;
    [SerializeField] private float fallingSpeed;

    private Rigidbody2D rigidbody2d;

    public static Cake CurrentCake { get; private set; }

    void OnEnable()
    {
        CurrentCake = this;
        rigidbody2d = GetComponent<Rigidbody2D>();

        rigidbody2d.velocity = new Vector2(1,0) * horizontalSpeed;
    }

    public void Stop()
    {
        rigidbody2d.velocity = new Vector2(-1, 0) * horizontalSpeed;
    }

    public void Fall()
    {
        rigidbody2d.velocity = new Vector2(0, -1) * fallingSpeed;
    }
}
