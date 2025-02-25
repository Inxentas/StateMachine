# StateMachine
StateMachine is, as it's name implies, a Statemachine package for UnityEngine.

## Initiating and running StateMachines
A basic StateMachine is set up once, and should be given an initial State. During gameplay (typically each frame) the machine's Run method keep it (you guessed it) running.

    public void Awake(){
    {
      machine = new StateMachine();
      machine.SetState(new State(machine));
    }

    public void Update()
    {
      machine.Run();
    }

## Creating your own StateMachines
The idea is that you extend the StateMachine and State classes to drive more specific behavior. Typically scope on the "thing" being governed is provided by passing it in a constructor.

    public void Awake(){
    {
      machine = new StateMachineEnemy(this);
      machine.SetState(new StateEnemy(machine));
    }

    public void Update()
    {
      machine.Run();
    }
