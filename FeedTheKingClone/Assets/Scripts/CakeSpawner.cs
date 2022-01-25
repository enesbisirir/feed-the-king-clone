using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSpawner : MonoBehaviour
{

    [SerializeField]
    private float spawnTimer;

    [SerializeField]
    private GameObject[] cakes;

    private GameObject lastRespawnedCake;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCake());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnCake()
    {
        while (true)
        {
            lastRespawnedCake = Instantiate(SelectCake(), transform.position, Quaternion.identity);

            // lastRespawnedCake.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);

            yield return new WaitForSeconds(spawnTimer);
        }
    }

    private GameObject SelectCake()
    {
        int cakeIndex = Random.Range(0, cakes.Length);
        return cakes[cakeIndex];
    }
}
