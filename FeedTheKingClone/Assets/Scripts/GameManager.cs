using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CakeSpawner cakeSpawner;
    [SerializeField] private Tray tray;

    void Start()
    {
        cakeSpawner.Spawn();
        Cake.Fallen += OnFallen;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CakeCollection.Cakes.CurrentCake().Fall();
        }

    }

    private void OnFallen(GameObject fallingObject, GameObject stationaryObject)
    {
        fallingObject.GetComponent<Cake>().Stop();
        cakeSpawner.Spawn();
    }

    private bool IsFallLegal(GameObject fallingObject, GameObject stationaryObject)
    {
        var fallingObjectICollidable = fallingObject.GetComponent<ICollidable>();
        var stationaryObjectICollidable = stationaryObject.GetComponent<ICollidable>();

        if (fallingObjectICollidable.BottomLeftCorner() > stationaryObjectICollidable.TopRightCorner() ||
            fallingObjectICollidable.BottomRightCorner() < stationaryObjectICollidable.TopLeftCorner())
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
