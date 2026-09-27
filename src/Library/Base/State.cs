using System.Collections.Generic;

namespace Ucu.Poo.StateMachine
{
  public abstract class State
  {
    public List<TransitionFunction> Transitions = new List<TransitionFunction>();

    public void AddTransition(InputSymbol input, State state)
    {
      foreach (TransitionFunction item in this.Transitions)
      {
        if (item.Input.GetType() == input.GetType())
        {
          return;
        }
      }

      TransitionFunction function = new TransitionFunction(input, state);
      this.Transitions.Add(function);
    }

    public State GetNextState(InputSymbol input)
    {
      foreach (TransitionFunction item in this.Transitions)
      {
        if (item.IsTriggered(input))
        {
          return item.NextState;
        }
      }

      return null;
    }

    public abstract void OnEnter();

    public abstract void OnExit();
  }
}