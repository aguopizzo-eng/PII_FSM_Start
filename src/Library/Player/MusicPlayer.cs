// -----------------------------------------------------------------------
// <copyright file="MusicPlayer.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------
namespace Ucu.Poo.StateMachine
{
  /// <summary>
  /// Esta clase representa un reproductor de música.
  /// </summary>
  public class MusicPlayer : StateMachine
  {
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="MusicPlayer"/>.
    /// </summary>
    /// <param name="initialState">El estado inicial del reproductor.</param>
    public MusicPlayer(State initialState) : base(initialState)
    {
      this.CurrentState = initialState;
    }
  }
}