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
            StringBuilder result = new StringBuilder();

            result.Append("Hero: ").AppendLine(PlayerInfo.Hero.GetType().Name);
            result.Append("Inventory: ");
            if (PlayerInfo.Hero.Inventory.Items.Count > 0)
            {
                result.AppendLine();
                PlayerInfo.Hero.Inventory.Items.ForEach(i => result.AppendLine(i.ToString()));
            }
            else
            {
                result.AppendLine("No items.");
            }

            return result.ToString();
        }
    }
}
