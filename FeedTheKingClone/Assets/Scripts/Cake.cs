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

    public static Action<GameObject, GameObject> Fallen { get; internal set; }
    public static Action<Cake> FallStarted { get; internal set; }

    private void OnEnable()
    {
        CakeCollection.Cakes.Add(this);
        rigidbody2d = GetComponent<Rigidbody2D>();

        MoveHorizontally();
    }

    private void MoveHorizontally()
    {
        int randomDirectionSign = UnityEngine.Random.Range(0, 2) * 2 - 1;
        rigidbody2d.velocity = new Vector2(randomDirectionSign, 0) * cakeAttributes.HorizontalSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this == CakeCollection.Cakes.CurrentCake() && !collision.gameObject.CompareTag("Wall"))
        {
            Fallen?.Invoke(this.gameObject, collision.gameObject);
        }
    }

    public void Fall()
    {
        rigidbody2d.velocity = new Vector2(0, -1) * cakeAttributes.FallingSpeed;
        FallStarted?.Invoke(this);
    }

    public void StopRigidbodyConstrains()
    {
        rigidbody2d.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void FreeFall()
    {
        GetComponent<SpriteRenderer>().sortingOrder += 1;
        Destroy(GetComponent<PolygonCollider2D>());
    }

    public void DestroyCakeAfterDelay()
    {
        CakeCollection.Cakes.Remove(this);
        Destroy(gameObject, cakeAttributes.IllegalFallDestroyDelay);
    }

    public GameObject TopLeftCorner() => topLeftCorner;
    public GameObject TopRightCorner() => topRightCorner;
    public GameObject BottomLeftCorner() => bottomLeftCorner;
    public GameObject BottomRightCorner() => bottomRightCorner;
}