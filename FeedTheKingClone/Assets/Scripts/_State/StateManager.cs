using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private BaseState currentState;
    private StateFactory stateFactory;
    private PlayerHealth playerHealth;
    private ObjectContainer container;

    private BaseState cakeFallState;
    private BaseState kingWaitingToEatState;
    private BaseState kingEatingState;

    void Awake()
    {
        stateFactory = new StateFactory();
        container = FindObjectOfType<ObjectContainer>();
    }

    void Start()
    {
        playerHealth = container.GetComponent("PlayerHealth") as PlayerHealth;

        playerHealth.HealthDecreased += OnHealthDecreased;
        KingWaitingToEatState.KingWaitingFinished += OnKingWaitingFinished;
        
        GetStatesFromFactory();

        currentState = cakeFallState;
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

    private void OnHealthDecreased(int health)
    {
        if (health > 0)
            return;

        SwitchState(kingWaitingToEatState);
    }

    private void OnKingWaitingFinished()
    {
        SwitchState(kingEatingState);
    }

    private void GetStatesFromFactory()
    {
        cakeFallState = stateFactory.GetState(GameState.CakeFallState, container);
        kingWaitingToEatState = stateFactory.GetState(GameState.KingWaitingToEatState, container);
        kingEatingState = stateFactory.GetState(GameState.KingEatingState, container);
    }

    private void OnDestroy()
    {
        playerHealth.HealthDecreased -= OnHealthDecreased;
    }
}
