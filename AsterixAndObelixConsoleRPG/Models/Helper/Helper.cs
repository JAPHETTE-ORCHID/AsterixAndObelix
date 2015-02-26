namespace AsterixAndObelixConsoleRPG.Models.Helper
{
    using System;
    using System.Collections.Generic;

    using Fields;

    internal class Helper
    {
        private static Dictionary<string, string> commands = new Dictionary<string, string>()
        {
            { Constants.MarketFieldCommand, "Here you can buy items from shop and become stronger." },
            { Constants.BattleFieldCommand, "Here you can fight with diference enemies, win items, level up end etc." },
            { Constants.AttackCommand, "With this command + \"emenmy name\" you can fight with enemies." },
            { Constants.InfoCommand, "This command show your hero stats and inventory." },
            { Constants.ClearCommand, "With this command you clear the all things from console." }
        };

        public static void DrawAllCommands()
        {
            Console.WriteLine("-------------------------------------------------------------------------------");
            Console.WriteLine("All command: ");
            Console.WriteLine("-------------------------------------------------------------------------------");
            foreach (string key in Helper.commands.Keys)
            {
                Console.WriteLine(key + ": " + Helper.commands[key]);
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
        }
    }
}
