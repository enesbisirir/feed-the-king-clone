using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour, ICollidable
{
    [SerializeField] private CakeAttributes cakeAttributes;
    [SerializeField] private GameObject topLeftCorner;
    [SerializeField] private GameObject topRightCorner;
    [SerializeField] private GameObject bottomLeftCorner;
    [SerializeField] private GameObject bottomRightCorner;

    private Rigidbody2D rigidbody2d;
    private CakeState cakeState;

    public Action Fallen { get; internal set; }

    void OnEnable()
    {
        CakeCollection.Cakes.Add(this);
        rigidbody2d = GetComponent<Rigidbody2D>();

        MoveHorizontally();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this == CakeCollection.Cakes.CurrentCake() && !collision.gameObject.CompareTag("Wall"))
        {
            cakeState = CakeState.Stationary;
            Fallen?.Invoke();
            rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    private void MoveHorizontally()
    {
        cakeState = CakeState.MovingHorizontally;
        int randomDirection = UnityEngine.Random.Range(0, 2) * 2 - 1;
        rigidbody2d.velocity = new Vector2(randomDirection, 0) * cakeAttributes.HorizontalSpeed;
    }

    public void Fall()
    {
        cakeState = CakeState.Falling;
        rigidbody2d.velocity = new Vector2(0, -1) * cakeAttributes.FallingSpeed;
    }

    public float TopLeftCorner() => topLeftCorner.transform.position.x;

    public float TopRightCorner() => topRightCorner.transform.position.x;

    public float BottomLeftCorner() => bottomLeftCorner.transform.position.x;

    public float BottomRightCorner() => bottomRightCorner.transform.position.x;

    public CakeState State() => cakeState;
}

public enum CakeState
{
    MovingHorizontally,
    Falling,
    Stationary
}