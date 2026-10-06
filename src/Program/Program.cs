//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using Ucu.Poo.Fsm;
using System;
using Ucu.Poo.StateMachine;

namespace Ucu.Poo.Fsm
{
    /// <summary>
    /// El programa principal.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            // Input Symbols.
            Play play = new Play();
            Stop stop = new Stop();
            Pause pause = new Pause();

            // States
            StoppedState stopped = new StoppedState();
            PlayingState playing = new PlayingState();
            PausedState paused = new PausedState();

            MusicPlayer player = new MusicPlayer(stopped);

            player.AddState(playing);
            player.AddState(paused);

            playing.AddTransition(pause, paused);
            playing.AddTransition(stop, stopped);

            stopped.AddTransition(play, playing);

            paused.AddTransition(play, playing);
            paused.AddTransition(stop, stopped);

            bool resultado = player.ProcessInputs(new InputSymbol[] { play, pause, stop} );
            Console.WriteLine(resultado);

            bool resultado2 = player.ProcessInputs(new InputSymbol[] { play, pause, pause} );
            Console.WriteLine(resultado2);
        }
    }
}
