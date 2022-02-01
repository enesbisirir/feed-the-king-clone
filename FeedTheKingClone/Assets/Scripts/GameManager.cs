using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CakeSpawner cakeSpawner;

    void Start()
    {
        cakeSpawner.Spawn();
        Cake.Fallen += OnFallen;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (CakeCollection.Cakes.PreviousCake() is Cake)
            {
                bool isLegal = IsFallLegal(CakeCollection.Cakes.CurrentCake(), CakeCollection.Cakes.PreviousCake());

                if (isLegal == true)
                {
                    Debug.Log("legal");
                }
                else
                {
                    Debug.Log("not legal");
                }

            }
            CakeCollection.Cakes.CurrentCake().Fall();
        }
    }

    private void OnFallen()
    {
        cakeSpawner.Spawn();
    }

    private bool IsFallLegal(ICollidable fallingItem, ICollidable stationaryItem)
    {
        if (fallingItem.BottomLeftCorner() > stationaryItem.TopRightCorner() || 
            fallingItem.BottomRightCorner() < stationaryItem.TopLeftCorner())
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
