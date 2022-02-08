using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] cakePrefabs;

    public void Spawn()
    {
        Instantiate(SelectCake(), transform.position, Quaternion.identity);
        Reposition();
    }

    //TODO: Select cakes to spawn based on time passed
    private GameObject SelectCake()
    {
        int cakeIndex = Random.Range(0, cakePrefabs.Length);
        return cakePrefabs[cakeIndex];
    }

    private void Reposition()
    {
        float cakePosX = Random.Range(-GAME_FIELD_X + (MaxCakeWidth / 2) + MARGIN,
                                       GAME_FIELD_X - (MaxCakeWidth / 2) - MARGIN);

        transform.position = new Vector3(cakePosX, transform.position.y, transform.position.z);
    }

    private float MaxCakeWidth
    {
        get
        {
            float maxWidth = 0f;
            foreach (GameObject cake in cakePrefabs)
            {
                ICollidable cakeICollidable = cake.GetComponent<ICollidable>();
                float topWidth = cakeICollidable.TopRightCorner().transform.position.x - cakeICollidable.TopLeftCorner().transform.position.x;
                float bottomWidth = cakeICollidable.BottomRightCorner().transform.position.x - cakeICollidable.BottomLeftCorner().transform.position.x;

                maxWidth = Mathf.Max(maxWidth, topWidth, bottomWidth);
            }

            return maxWidth;
        }
    }


    const float GAME_FIELD_X = 2.8f;
    const float MARGIN = .1f;
}
