using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    [SerializeField] private CakeSpawner cakeSpawner;
    [SerializeField] private Tray tray;
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private King king;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private HealthRenderer healthRenderer;

    private PlayerHealth playerHealth;

    private Dictionary<string, object> components;

    private void Awake()
    {
        playerHealth = new PlayerHealth();

        components = new Dictionary<string, object>
        {
            { "CakeSpawner", cakeSpawner },
            { "Tray", tray },
            { "InputHandler", inputHandler },
            { "King", king },
            { "PlayerHealth", playerHealth },
            { "HealthRenderer", healthRenderer },
            { "CameraController", cameraController }
        };
    }

    public new object GetComponent(string componentKey)
    {
        if (!components.ContainsKey(componentKey))
        {
            return null;
        }

        return components[componentKey];
    }
}
