using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private BaseState currentState;
    private StateFactory stateFactory;
    private ObjectContainer container;

    private void Awake()
    {
        container = FindObjectOfType<ObjectContainer>();
    }

    void Start()
    {
        currentState = stateFactory.GetState(GameState.CakeFallState, container);
        currentState.Enter();
    }

    void Update()
    {
        
    }
}
