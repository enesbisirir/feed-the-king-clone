using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    //private bool isFollowing = false;

    private void Update()
    {
        //if (isFollowing)
        //{
        //    FollowTouch();
        //}
    }

    public void FollowTouch()
    {
        var touchPos = Camera.main.ScreenToWorldPoint(InputHandler.TouchPosition);
        touchPos.y = transform.position.y;

        transform.position = Vector2.Lerp(transform.position, touchPos, Time.deltaTime * speed);
    }

    //public void SetFollowing(bool follow)
    //{
    //    isFollowing = follow;
    //}
}
