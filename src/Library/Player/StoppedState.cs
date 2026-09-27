using System;
namespace Ucu.Poo.StateMachine
{
  public class StoppedState : State
  {
    public override void OnEnter()
    {
      Console.WriteLine("El reproductor está stopped.");
    }

    public override void OnExit()
    {
      Console.WriteLine("El estado stopped terminará ahora.");
    }
  }
}