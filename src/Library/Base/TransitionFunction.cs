// -----------------------------------------------------------------------
// <copyright file="TransitionFunction.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------
namespace Ucu.Poo.StateMachine
{
  /// <summary>
  /// Esta clase representa una transición: asocia un input con el estado al que se debe pasar cuando ese input ocurre.
  /// </summary>
  public class TransitionFunction
  {
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="TransitionFunction"/>.
    /// </summary>
    /// <param name="input">El input que dispara esta transición.</param>
    /// <param name="nextState">El estado al que se debe pasar cuando ocurre el input.</param>
    public TransitionFunction(InputSymbol input, State nextState)
    {
      this.Input = input;
      this.NextState = nextState;
    }

    /// <summary>
    /// Representa el input que dispara esta transición.
    /// </summary>
    public InputSymbol Input { get; }

    /// <summary>
    /// Representa el estado al que se debe pasar cuando ocurre el input.
    /// </summary>
    public State NextState { get; }

    /// <summary>
    /// Determina si un input dado dispara esta transición.
    /// </summary>
    /// <param name="input">El input a evaluar.</param>
    /// <returns><c>true</c> si el input es del mismo tipo que <see cref="Input"/>; <c>false</c> en caso contrario.</returns>
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
