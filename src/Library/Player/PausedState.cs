using System;
namespace Ucu.Poo.StateMachine
{
  public class PausedState : State
  {
    public override void OnEnter()
    {
      Console.WriteLine("El reproductor está paused.");
    }

    public override void OnExit()
    {
      Console.WriteLine("El estado paused terminará ahora.");
    }
  }
}