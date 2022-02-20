using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float time = .2f;
    [SerializeField] private AnimationCurve curve;

    private void OnEnable()
    {
        Cake.Fallen += OnFallen;
    }

    private void OnFallen(GameObject cake, GameObject ground)
    {
        StopAllCoroutines();
        StartCoroutine(MoveCamera(TargetAfterCakeFall(cake)));
    }

    private Vector3 TargetAfterCakeFall(GameObject cake)
    {
        ICollidable cakeICollidable = cake.GetComponent<ICollidable>();
        float cakeHeight = cakeICollidable.TopLeftCorner().transform.position.y - cakeICollidable.BottomLeftCorner().transform.position.y;

        return new Vector3(transform.position.x, transform.position.y + cakeHeight, transform.position.z);
    }

    private IEnumerator MoveCamera(Vector3 target)
    {
        float timePassed = 0f;
        while (time > timePassed)
        {
            timePassed += Time.deltaTime;

            var normalized = timePassed / time;
            normalized = curve.Evaluate(normalized);

            transform.position = Vector3.Lerp(transform.position, target, normalized);
            yield return null;
        }
    }
}
