using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnTimer;

    [SerializeField]
    private GameObject[] cakePrefabs;

    private GameObject lastCakeSpawned;
    private static List<GameObject> cakesSpawned = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnCake(spawnTimer));
    }

    private IEnumerator SpawnCake(float spawnTimer)
    {
        while (true)
        {
            lastCakeSpawned = Instantiate(SelectCake(), transform.position, Quaternion.identity);

            cakesSpawned.Add(lastCakeSpawned);
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    //TODO: Select cakes based on time passed
    private GameObject SelectCake()
    {
        int cakeIndex = Random.Range(0, cakePrefabs.Length);
        return cakePrefabs[cakeIndex];
    }

    public static List<GameObject> GetCakesSpawned(){
        return cakesSpawned;
        }
}
