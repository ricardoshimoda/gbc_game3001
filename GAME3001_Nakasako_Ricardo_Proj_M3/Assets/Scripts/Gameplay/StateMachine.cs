using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IState
{
    protected StateMachine sm;
    protected List<IState> states;
    protected AgentScript actor;

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

public class StateMachine
{
    IState currentState;

    public void ChangeState(IState newState)
    {
        if (currentState != null)
            currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        if (currentState != null)
            currentState.Update();
    }
}