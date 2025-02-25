using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTimerNext : State
{
    public StateTimerNext(StateMachine machine, State nextState) : base(machine) { this.nextState = nextState; }

    public State nextState;

    public float timer = 0;

    public float delay = 1;

    public override void OnStateEnter()
    {
        this.timer = 0;
        base.OnStateEnter();
    }

    public override void OnStateUpdate()
    {
        if (delay > 0 && nextState != null)
        {
            this.timer += (Time.deltaTime * Time.timeScale);
            if (timer > delay) { machine.SetState(nextState); }
        }
        else
        {
            Debug.LogError("this StateTimer never had a state set.");
        }
        base.OnStateUpdate();
    }

    public override void OnStateExit()
    {
        this.timer = 0;
        base.OnStateExit();
    }
}
