using System;

namespace AsterixAndObelixConsoleRPG
{
    using AsterixAndObelixConsoleRPG.Core;

    internal class MainGame
    {
        internal static void Main()
        {
            Game game = new Game();
            game.Start();
        }
    }
}