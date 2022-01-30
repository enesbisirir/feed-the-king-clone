using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    [SerializeField] private CakeAttributes cakeAttributes;

    private Rigidbody2D rigidbody2d;

    public Action Fell { get; internal set; }

    void OnEnable()
    {
        CakeCollection.Cakes.Add(this);

        rigidbody2d = GetComponent<Rigidbody2D>();

        MoveHorizontally();
    }

    private void MoveHorizontally()
    {
        rigidbody2d.velocity = new Vector2(1, 0) * cakeAttributes.HorizontalSpeed;
    }

    public void Fall()
    {
        rigidbody2d.velocity = new Vector2(0, -1) * cakeAttributes.FallingSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.y > collision.gameObject.transform.position.y)
        {
            if (collision.gameObject.TryGetComponent<Tray>(out Tray tray) ||
                collision.gameObject.TryGetComponent<Cake>(out Cake cake))
            {
                Fell?.Invoke();
                rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }
}