using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<GameObject> cakes;

    // Start is called before the first frame update
    void Start()
    {
        cakes = CakeSpawner.GetCakesSpawned();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
