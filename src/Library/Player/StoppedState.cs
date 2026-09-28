// -----------------------------------------------------------------------
// <copyright file="StoppedState.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------
using System;
namespace Ucu.Poo.StateMachine
{
  /// <summary>
  /// Esta clase representa el estado "stopped".
  /// </summary>
  public class StoppedState : State
  {
    /// <summary>
    /// Imprime en consola que el reproductor entró en estado "stopped".
    /// </summary>
    public override void OnEnter()
    {
      Console.WriteLine("El reproductor está stopped.");
    }

    /// <summary>
    /// Imprime en consola que el reproductor salió del estado "stopped".
    /// </summary>
    public override void OnExit()
    {
      Console.WriteLine("El estado stopped terminará ahora.");
    }
  }
}