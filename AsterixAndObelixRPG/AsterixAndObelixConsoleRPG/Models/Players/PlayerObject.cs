namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Models.Fields;

    public abstract class PlayerObject : IAttack, IDefence, IUnit, IUpdatable
    {
        private int attack;
        private int defence;
        private int health;

        public PlayerObject(int attack, int defence, int health)
        {
            this.Attack = attack;
            this.Defence = defence;
            this.Health = health;
        }

        public int Attack
        {
            get
            {
                return this.attack;
            }

            set
            {
                Validator.CheckForNegativeNumber(value);
                this.attack = value;
            }
        }

        public int Defence
        {
            get
            {
                return this.defence;
            }

            set
            {
                Validator.CheckForNegativeNumber(value);
                this.defence = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }

            set
            {
                Validator.CheckForNegativeNumber(value);
                this.health = value;
            }
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }


        public void MakeAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}