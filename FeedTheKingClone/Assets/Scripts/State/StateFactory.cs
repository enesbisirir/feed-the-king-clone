using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFactory
{
    public BaseState GetState(GameState gameState)
    {
        return gameState switch
        {
            GameState.CakeFallState => new CakeFallState(),
            GameState.KingEatingState => new KingEatingState(),
            _ => null,
        };
    }
}
