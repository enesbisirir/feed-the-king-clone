using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private BaseState currentState;
    private StateFactory stateFactory;

    void Start()
    {
        currentState = stateFactory.GetState(GameState.CakeFallState);
        currentState.Enter();
    }

    void Update()
    {
        
    }
}
