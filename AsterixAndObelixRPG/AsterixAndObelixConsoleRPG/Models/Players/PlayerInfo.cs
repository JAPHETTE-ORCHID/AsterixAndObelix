using System.Linq;
using System.Runtime.InteropServices;

namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using System;
    using System.Collections.Generic;
    using AsterixAndObelixConsoleRPG.Contracts;

    public static class PlayerInfo
    {
        private static Hero hero;
        private static List<IItem> items = new List<IItem>();

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

        public static List<IItem> Items
        {
            get
            {
                return PlayerInfo.items;
            }

            set
            {
                PlayerInfo.items = value;
            }
        }

        public static string Show()
        {
            string playerInfo = "Hero: " + PlayerInfo.Hero.ToString() + "; Items: " + String.Join(" ", PlayerInfo.Items);

            return playerInfo;
        }
    }
}
