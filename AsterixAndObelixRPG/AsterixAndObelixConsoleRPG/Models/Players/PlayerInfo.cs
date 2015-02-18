using System.Linq;
using System.Runtime.InteropServices;

namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using System;
    using System.Collections.Generic;
    using AsterixAndObelixConsoleRPG.Contracts;
    using System.Text;

    public static class PlayerInfo
    {
        private static Hero hero;

        public static Hero Hero
        {
            get
            {
                return PlayerInfo.hero;
            }

            set
            {
                PlayerInfo.hero = value;
            }
        }

        public static string Show()
        {
            string stringOfHero = PlayerInfo.Hero.ToString();

            return stringOfHero;
        }
    }
}
