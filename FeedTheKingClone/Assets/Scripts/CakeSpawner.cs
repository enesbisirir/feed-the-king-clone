using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSpawner : MonoBehaviour
{

    [SerializeField]
    private float spawnTimer;

    [SerializeField]
    private GameObject[] cakes;

    void Start()
    {
        StartCoroutine(SpawnCake());
    }

    private IEnumerator SpawnCake()
    {
        while (true)
        {
            Instantiate(SelectCake(), transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    //TODO: Select cakes based on time passed
    private GameObject SelectCake()
    {
        int cakeIndex = Random.Range(0, cakes.Length);
        return cakes[cakeIndex];
    }
}
