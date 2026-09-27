using System;
namespace Ucu.Poo.StateMachine
{
  public class PlayingState : State
  {
    public override void OnEnter()
    {
      Console.WriteLine("El reproductor está playing");
    }

    public override void OnExit()
    {
      Console.WriteLine("El estado playing terminará ahora.");
    }
  }
}