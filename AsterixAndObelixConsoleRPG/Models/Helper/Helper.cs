namespace AsterixAndObelixConsoleRPG.Models.Helper
{
    using AsterixAndObelixConsoleRPG.Models.Fields;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    class Helper
    {
        private static Dictionary<string, string> commands = new Dictionary<string, string>()
        {
            {Constants.MarketFieldCommand, ""},
            {Constants.BattleFieldCommand, ""},
            {Constants.AttackCommand, ""},
            {Constants.InfoCommand, ""},
            {Constants.ClearCommand, ""},
            {Constants.ExitCommand, ""},
        };

        public static void DrawAllCommands()
        {
            Console.WriteLine("All command: ");
            foreach (string key in Helper.commands.Keys)
            {
                System.Console.WriteLine(key + ": " + Helper.commands[key]);
            }
        }
    }
}
