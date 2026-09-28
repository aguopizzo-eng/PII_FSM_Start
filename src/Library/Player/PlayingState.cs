// -----------------------------------------------------------------------
// <copyright file="PlayingState.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------
using System;
namespace Ucu.Poo.StateMachine
{
  /// <summary>
  /// Esta clase representa el estado "playing".
  /// </summary>
  public class PlayingState : State
  {
    /// <summary>
    /// Imprime en consola que el reproductor entró en estado "playing".
    /// </summary>
    public override void OnEnter()
    {
      Console.WriteLine("El reproductor está playing");
    }

    /// <summary>
    /// Imprime en consola que el reproductor salió del estado "playing".
    /// </summary>
    public override void OnExit()
    {
      Console.WriteLine("El estado playing terminará ahora.");
    }
  }
}