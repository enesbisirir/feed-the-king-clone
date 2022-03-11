using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private BaseState currentState;
    private StateFactory stateFactory;
    private PlayerHealth playerHealth;
    private ObjectContainer container;

    void Awake()
    {
        stateFactory = new StateFactory();
        container = FindObjectOfType<ObjectContainer>();

    }

    void Start()
    {
        playerHealth = container.GetComponent("PlayerHealth") as PlayerHealth;
        playerHealth.Dead += OnDead;

        currentState = stateFactory.GetState(GameState.CakeFallState, container);
        currentState.Enter();
    }

    void Update()
    {
        currentState.Update();
    }

    private void SwitchState(BaseState targetState)
    {
        currentState.Exit();

        currentState = targetState;

        currentState.Enter();
    }

    private void OnDead()
    {
        var kingEatingState = stateFactory.GetState(GameState.KingEatingState, container);
        SwitchState(kingEatingState);
    }
}
