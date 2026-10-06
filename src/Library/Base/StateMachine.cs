// -----------------------------------------------------------------------
// <copyright file="StateMachine.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
// -----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace Ucu.Poo.StateMachine
{
  /// <summary>
  /// Esta clase representa una máquina de estado genérica.
  /// </summary>
  public abstract class StateMachine
  {
    /// <summary>
    /// Representa un diccionario que como Clave guarda el tipo del objeto y como valor guarda la instancia.
    /// </summary>
    private Dictionary<Type, State> states = new Dictionary<Type, State>();

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="StateMachine"/>.
    /// </summary>
    /// <param name="initialState">Representa el estado inicial de la máquina de estado.</param>
    public StateMachine(State initialState)
    {
      this.CurrentState = initialState;
    }

    /// <summary>
    /// Representa una propiedad de solo lectura que devuelve los valores que contiene el diccionario.
    /// </summary>
    public ReadOnlyCollection<State> States { get { return this.states.Values.ToList<State>().AsReadOnly(); } }

    /// <summary>
    /// Representa el estado actual de la máquina de estado.
    /// </summary>
    public State CurrentState { get; set; }

    /// <summary>
    /// Añade un nuevo estado posible para la máquina de estado, preguntando si una instancia del estado que se desea agregar ya existe.
    /// </summary>
    /// <param name="state">El estado a agregar a la máquina de estado.</param>
    public void AddState(State state)
    {
      if (!this.states.ContainsKey(state.GetType()))
      {
        this.states.Add(state.GetType(), state);
      }
    }

    /// <summary>
    /// Procesa un input: si el estado actual tiene una transición para ese input, actualiza <see cref="CurrentState"/> al estado destino; si no, no hace nada.
    /// </summary>
    /// <param name="input">El input a procesar.</param>
    /// <returns><c>true</c> si el input disparó una transición válida; <c>false</c> si el input se ignoró.</returns>
    public bool ProcessInput(InputSymbol input)
    {
      State nextState = this.CurrentState.GetNextState(input);
      if (nextState != null)
      {
        this.CurrentState.OnExit();
        this.CurrentState = nextState;
        this.CurrentState.OnEnter();

        return true;
      }

      return false;
    }

    /// <summary>
    /// Procesa una secuencia de inputs en orden, llamando a <see cref="ProcessInput"/> para cada uno. Se detiene apenas un input no dispara ninguna transición.
    /// </summary>
    /// <param name="args">La secuencia de inputs a procesar.</param>
    /// <returns><c>true</c> si todos los inputs de la secuencia dispararon una transición válida; <c>false</c> si alguno se ignoró.</returns>
    public bool ProcessInputs(InputSymbol[] args)
    {
      foreach (InputSymbol item in args)
      {
        bool boolValue = this.ProcessInput(item);
        if (!boolValue)
        {
          return false;
        }
      }

      return true;
    }
  }
}