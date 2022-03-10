using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    [SerializeField] private CakeSpawner cakeSpawner;
    [SerializeField] private Tray tray;
    [SerializeField] private InputHandler inputHandler;
    [SerializeField] private King king;

    private Dictionary<string, object> components;

    private void Awake()
    {
        components.Add("CakeSpawner", cakeSpawner);
        components.Add("Tray", tray);
        components.Add("InputHandler", inputHandler);
        components.Add("King", cakeSpawner);
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
