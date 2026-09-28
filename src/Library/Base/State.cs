// -----------------------------------------------------------------------
// <copyright file="State.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------
using System.Collections.Generic;

namespace Ucu.Poo.StateMachine
{
  /// <summary>
  /// Esta clase representa un estado de una máquina de estado genérica.
  /// </summary>
  public abstract class State
  {
    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="State"/>.
    /// </summary>
    public State()
    {
      this.Transitions = new List<TransitionFunction>();
    }

    /// <summary>
    /// Representa una colección de transiciones que conoce el estado.
    /// </summary>
    public List<TransitionFunction> Transitions { get; }

    /// <summary>
    /// Añade una transición a la lista, siempre que no exista ya una transición registrada para el mismo input.
    /// </summary>
    /// <param name="input">Un input symbol que dispara la transición.</param>
    /// <param name="state">Un estado al que llega la transición.</param>
    public void AddTransition(InputSymbol input, State state)
    {
      foreach (TransitionFunction item in this.Transitions)
      {
        if (item.Input.GetType() == input.GetType())
        {
          return;
        }
      }

      TransitionFunction function = new TransitionFunction(input, state);
      this.Transitions.Add(function);
    }

    /// <summary>
    /// Busca, entre las transiciones registradas, cuál es el próximo estado para un input dado.
    /// </summary>
    /// <param name="input">Un input symbol que dispara la búsqueda del próximo estado.</param>
    /// <returns>El estado al que se debe pasar según la transición encontrada, o <c>null</c> si el input no dispara ninguna transición desde este estado.</returns>
    public State GetNextState(InputSymbol input)
    {
      foreach (TransitionFunction item in this.Transitions)
      {
        if (item.IsTriggered(input))
        {
          return item.NextState;
        }
      }

      return null;
    }

    /// <summary>
    /// Ejecuta las acciones correspondientes al entrar la máquina de estado a este estado.
    /// </summary>
    public abstract void OnEnter();

    /// <summary>
    /// Ejecuta las acciones correspondientes al salir la máquina de estado de este estado.
    /// </summary>
    public abstract void OnExit();
  }
}