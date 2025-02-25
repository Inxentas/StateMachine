using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StateMachine
{
    [SerializeField] protected State _currentState;

    public State currentState { get { return _currentState; } }

    /**
     * Not sure what to call this... a 'constructor pattern'?
     * We can modify the constructor to use a more concrete class.
     */
    public StateMachine()
    {
        //Debug.Log(this + " : StateMachine : " + unit.name);
    }

    /**
     * We must always set an initial state externally. For some
     * reason it doesn't work when fired from concrete constructors.
     */
    public void InitState(State state)
    {
        _currentState = state;
        _currentState.OnStateEnter();
    }
    
    /*
     * Before we switch states, we fire the OnStateExit method
     * of the current State. Then we swap them out, and fire the
     * OnStateEnter method of the new State. States should 'clean
     * themselves up' before another State takes over control.
     */
    public void SetState(State state)
    {
        if (_currentState != null)
        {
            _currentState.OnStateExit();
        }
        _currentState = state;
        if (_currentState != null)
        {
            _currentState.OnStateEnter();
        }
    }

    /*
     * The Run method basically gives the StateMachine a whirl every
     * update cycle, or whenever you want it to.
     */
    public void Run()
    {
        if (_currentState != null)
        { 
            currentState.OnStateUpdate();
        }
    }
}