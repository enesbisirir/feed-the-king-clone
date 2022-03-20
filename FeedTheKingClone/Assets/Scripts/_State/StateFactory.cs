using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFactory
{
    public BaseState GetState(GameState gameState, ObjectContainer container)
    {
        return gameState switch
        {
            GameState.CakeFallState => new CakeFallState(container),
            GameState.KingEatingState => new KingEatingState(container),
            GameState.KingWaitingToEatState => new KingWaitingToEatState(container),
            _ => null,
        };
    }
}
