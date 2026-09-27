namespace Ucu.Poo.StateMachine
{
  public class MusicPlayer : StateMachine
  {
    public MusicPlayer(State initialState) : base(initialState)
    {
      this.CurrentState = initialState;
    }
  }
}