using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseState
{
    public abstract void EnterState();
    public abstract void HandleFixedUpdate();
    public abstract void HandleUpdate();
    public abstract void ExitState();
    public abstract void HandleCollide(Collision2D collision);
    public abstract void HandleTrigger(Collider2D collider);
}


public abstract class BaseFSM
{
    public BaseState currentState { protected set; get; }

    public void TransitState(BaseState newState)
    {
        currentState.ExitState();
        currentState = null;
        currentState = newState;
    }
}


