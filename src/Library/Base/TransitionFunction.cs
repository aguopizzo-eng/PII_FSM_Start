namespace Ucu.Poo.StateMachine
{
  public class TransitionFunction
  {
    public InputSymbol Input { get; }

    public State NextState { get; }

    public TransitionFunction(InputSymbol input, State nextState)
    {
      this.Input = input;
      this.NextState = nextState;
    }

    public bool IsTriggered(InputSymbol input)
    {
      if (this.Input.GetType() == input.GetType())
      {
        return true;
      }

      return false;
    }
  }
}