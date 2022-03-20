using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Action TouchStarted { get; internal set; }
    public static Vector2 TouchPosition;

    private Touch touch;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                TouchStarted?.Invoke();
            }
            TouchPosition = touch.position;
        }

    }
}