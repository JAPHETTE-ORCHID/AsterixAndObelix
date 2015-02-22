namespace AsterixAndObelixConsoleRPG.Models.Fields
{
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
    }
}