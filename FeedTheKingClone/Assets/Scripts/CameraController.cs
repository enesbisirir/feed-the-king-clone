using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cakeFallMovementTime = .2f;
    [SerializeField] private float moveToKingTimeMultiplier = .3f;
    [SerializeField] private AnimationCurve curve;
    private float moveToKingTimeInSeconds => moveToKingTimeMultiplier * CakeCollection.Cakes.CakeCount;

    private void OnEnable()
    {
        Cake.Fallen += OnFallen;
        KingEatingState.KingStateEntered += OnKingStateEntered;
    }

    private void OnKingStateEntered(King king)
    {
        StopAllCoroutines();
        var futurePosition = king.transform.position;
        futurePosition.z = transform.position.z;
        StartCoroutine(MoveCamera(futurePosition, moveToKingTimeInSeconds));
    }

    private void OnFallen(GameObject cake, GameObject ground)
    {
        StopAllCoroutines();
        var futurePosition = TargetPositionAfterCakeFall(cake);
        StartCoroutine(MoveCamera(futurePosition, cakeFallMovementTime));
    }

    private Vector3 TargetPositionAfterCakeFall(GameObject cake)
    {
        ICollidable cakeICollidable = cake.GetComponent<ICollidable>();
        float cakeHeight = cakeICollidable.TopLeftCorner().transform.position.y - cakeICollidable.BottomLeftCorner().transform.position.y;

        return new Vector3(transform.position.x, transform.position.y + cakeHeight, transform.position.z);
    }

    private IEnumerator MoveCamera(Vector3 target, float movementTime)
    {
        float timePassed = 0f;
        while (movementTime > timePassed)
        {
            timePassed += Time.deltaTime;

            var normalized = timePassed / movementTime;
            normalized = curve.Evaluate(normalized);

            transform.position = Vector3.Lerp(transform.position, target, normalized);
            yield return null;
        }
    }

        private void OnDisable()
    {
        Cake.Fallen -= OnFallen;
        KingEatingState.KingStateEntered -= OnKingStateEntered;
    }
}
