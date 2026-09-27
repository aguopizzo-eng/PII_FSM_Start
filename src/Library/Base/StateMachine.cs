using System;
using System.Collections.Generic;
namespace Ucu.Poo.StateMachine
{
  public class StateMachine
  {
    private List<State> states = new List<State>();

    public StateMachine(State initialState)
    {
      this.CurrentState = initialState;
    }

    public State CurrentState { get; set; }

    public void AddState(State state)
    {
      if (!states.Contains(state))
      {
        this.states.Add(state);
      }
    }

    public bool ProcessInput(InputSymbol input)
    {
      State nextState = this.CurrentState.GetNextState(input);
      if (nextState != null)
      {
        this.CurrentState.OnExit();
        this.CurrentState = nextState;
        this.CurrentState.OnEnter();

        return true;
      }

      return false;
    }

    public bool ProcessInputs(InputSymbol[] args)
    {
      foreach (InputSymbol item in args)
      {
        bool boolValue = this.ProcessInput(item);
        if (!boolValue)
        {
          return false;
        }
      }

      return true;
    }

  }
}