using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    [SerializeField] private CakeAttributes cakeAttributes;

    private Rigidbody2D rigidbody2d;

    public static Cake CurrentCake { get; private set; }

    public event Action OnFell;

    void OnEnable()
    {
        CurrentCake = this;
        rigidbody2d = GetComponent<Rigidbody2D>();

        rigidbody2d.velocity = new Vector2(1, 0) * cakeAttributes.HorizontalSpeed;
    }

    public void Stop()
    {
        rigidbody2d.velocity = new Vector2(-1, 0) * cakeAttributes.HorizontalSpeed;
    }

    public void Fall()
    {
        rigidbody2d.velocity = new Vector2(0, -1) * cakeAttributes.FallingSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Tray>(out Tray tray) || 
            collision.gameObject.TryGetComponent<Cake>(out Cake cake))
        {
            OnFell?.Invoke();
        }
    }
}
