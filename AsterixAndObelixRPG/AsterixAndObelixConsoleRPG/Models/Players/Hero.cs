namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using AsterixAndObelixConsoleRPG.Models.Fields;

    public abstract class Hero : PlayerObject
    {
        private int experience;
        private int gold;
        private string name;

        public Hero(string name, int attack, int defence, int health)
            : base(attack, defence, health)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckForEmptyOrNull(value);
                this.name = value;
            }
        }
        public int Experience
        {
            get
            {
                return this.experience;
            }
            set
            {
                Validator.CheckForNegativeNumber(value);
                this.experience = value;
            }
        }

        public int Gold
        {
            get
            {
                return this.gold;
            }
            set
            {
                Validator.CheckForNegativeNumber(value);
                this.gold = value;
            }
        }
        public int Level
        {
            get
            {
                int level = (this.experience / Constants.expPerLevel) + 1;

                return level;
            }
        }
    }
}