using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class State
{
    /*
     * States are intended for enemies and other objects that require complex behaviours.
     * As such the base class "subject" variable is CombatUnit, our NavMeshAgent manager.
     * The second parameter of the constructor is for the StateMachine itself, to ensure
     * all States have a reference to their respective State Machines. Extensions of this
     * class may crystalize the CombatUnit variable into a more specific one, to obtain
     * scope to the public methods of the "subject" variable. In other words, by modifying
     * constructors we open up the option to run the public methods of specific "subjects".
     */
    
    [NonSerialized] public StateMachine machine;    // our "machine" variable
    [SerializeField] public string name;

    /*
     * Instantiation requires a CombatUnit or any class that extends it, as well as the
     * StateMachine to which this state is tied.
     */
    public State(StateMachine machine)
    {
        this.name = this.GetType().ToString();
        this.machine = machine;
    }
    /*
     * Fired by State Machines  when a State is first entered.
     */
    virtual public void OnStateEnter()
    {
        //Debug.Log(this + " OnStateEnter");
    }
    /*
     * Fired continiously during an Update cycle.
     */
    virtual public void OnStateUpdate()
    {
        //Debug.Log(this + " OnStateUpdate");
    }
    /*
     * Fired by State Machines when the State is left.
     */
    virtual public void OnStateExit()
    {
        //Debug.Log(this + " OnStateExit");
    }
}

/*
 * Here are some example states that would work on any CombatUnit. Most of them actually
 * do jack shit, they primarily serve as an example of how each of the On.. methods can
 * be overridden, based, etc. 
 */

/*
 * The virtual methods are all overridden in this example.
 */
public class StateIdle : State
{
    public StateIdle(StateMachine machine) : base(machine) { }

    override public void OnStateEnter()
    {
        base.OnStateEnter();
    }
    override public void OnStateUpdate()
    {
        base.OnStateUpdate();
    }
    override public void OnStateExit()
    {
        base.OnStateEnter();
    }
}

/*
 * Only one virtual method is overridden in this example.
 */
public class StateApproach : State
{
    public StateApproach(StateMachine machine) : base(machine) { }

    override public void OnStateUpdate()
    {
        base.OnStateUpdate();
    }
}