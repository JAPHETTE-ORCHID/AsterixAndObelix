namespace AsterixAndObelixConsoleRPG.Models.Fields
{
    using System.Text;

    using Players;

    public abstract class Field
    {
        private static Hero hero;

        public static Hero Hero
        {
            get
            {
                return Field.hero;
            }

            set
            {
                Field.hero = value;
            }
        }

        public static string PrintHero()
        {
            StringBuilder printBattleField = new StringBuilder();
            printBattleField.AppendLine();
            if (BattleField.Hero == null)
            {
                printBattleField.AppendLine("No hero.");
            }
            else
            {
                printBattleField.AppendLine(BattleField.Hero.ToString());
            }

            return printBattleField.ToString();
        }
    }
}