namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using AsterixAndObelixConsoleRPG.Contracts;

    public abstract class PlayerObject : IAttack, IDefence, IUnit
    {
        public int Attack
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
                throw new System.NotImplementedException();
            }
        }

        public int Defence
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
                throw new System.NotImplementedException();
            }
        }

        public int Health
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}