using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTimer : State
{
    public StateTimer(StateMachine machine) : base(machine) { }

    public float duration = 0.4f;
    public float timer = 0.0f;
    public float progress = 0.0f;

    public override void OnStateEnter()
    {
        this.timer = 0;
        base.OnStateEnter();
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        this.timer += (Time.deltaTime * Time.timeScale);
        this.progress = this.timer / this.duration;
        this.progress = Mathf.Clamp(this.progress, 0, 1);
    }

    public override void OnStateExit()
    {
        this.timer = 1;
        base.OnStateExit();
    }
}
