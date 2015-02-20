namespace AsterixAndObelixConsoleRPG.Models.Fields
{
    using AsterixAndObelixConsoleRPG.Models.Players;

    public abstract class Field
    {
        private static Hero hero;

        public static Hero Hero
        {
            get
            {
                return BattleField.hero;
            }

            set
            {
                BattleField.hero = value;
            }
        }
    }
}