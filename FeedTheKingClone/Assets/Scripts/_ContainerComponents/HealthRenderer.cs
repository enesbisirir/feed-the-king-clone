using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthRenderer : MonoBehaviour
{
    [SerializeField] private Sprite heartEmpty;
    [SerializeField] private List<Image> hearts;

    private ObjectContainer container;
    private PlayerHealth playerHealth;

    private void Start()
    {
        container = FindObjectOfType<ObjectContainer>();

        playerHealth = container.GetComponent("PlayerHealth") as PlayerHealth;
        playerHealth.HealthDecreased += OnDecreaseHealth;
    }

    public void ShowHearts()
    {
        foreach (var heart in hearts)
        {
            heart.gameObject.SetActive(true);
        }
    }

    private void OnDecreaseHealth(int health) => EmptyNextHeart(health);

    private void EmptyNextHeart(int currentHealth)
    {
        hearts[currentHealth].sprite = heartEmpty;
    }
}
