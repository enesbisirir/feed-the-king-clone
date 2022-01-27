using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnTimer;

    [SerializeField]
    private GameObject[] cakePrefabs;

    void Start()
    {
        StartCoroutine(SpawnCake(spawnTimer));
    }

    private IEnumerator SpawnCake(float spawnTimer)
    {
        while (true)
        {
            Instantiate(SelectCake(), transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    //TODO: Select cakes to spawn based on time passed
    private GameObject SelectCake()
    {
        int cakeIndex = Random.Range(0, cakePrefabs.Length);
        return cakePrefabs[cakeIndex];
    }
}
