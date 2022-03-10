using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    protected abstract void OnEnter();
    protected abstract void OnUpdate();
    protected abstract void OnExit();

    public void Enter() => OnEnter();
    public void Update() => OnUpdate();
    public void Exit() => OnExit();
}
