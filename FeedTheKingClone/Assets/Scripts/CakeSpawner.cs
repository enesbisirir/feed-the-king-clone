using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] cakePrefabs;

    public void Spawn()
    {
        Instantiate(SelectCake(), transform.position, Quaternion.identity);
    }

    //TODO: Select cakes to spawn based on time passed
    private GameObject SelectCake()
    {
        int cakeIndex = Random.Range(0, cakePrefabs.Length);
        return cakePrefabs[cakeIndex];
    }
}
