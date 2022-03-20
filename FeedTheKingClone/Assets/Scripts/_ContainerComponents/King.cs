using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] private float followTouchSpeed = 1f;
    [SerializeField] private float escalationSpeed = 1f;
    private Rigidbody2D rigidbody2d;
    private Camera _camera;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        _camera = Camera.main;
    }

    public void FollowTouch()
    {
        var touchPos = _camera.ScreenToWorldPoint(InputHandler.TouchPosition);
        touchPos.y = transform.position.y;

        transform.position = Vector2.Lerp(transform.position, touchPos, Time.deltaTime * followTouchSpeed);
    }

    public void Escalate()
    {
        rigidbody2d.velocity = Vector2.up * escalationSpeed;
    }

    public void StopMovement()
    {
        rigidbody2d.velocity = Vector2.zero;
    }
}
