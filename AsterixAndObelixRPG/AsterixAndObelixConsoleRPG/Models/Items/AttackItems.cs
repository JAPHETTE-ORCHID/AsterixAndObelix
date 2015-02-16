using AsterixAndObelixConsoleRPG.Contracts;

namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class AttackItems : Item, IAttack
    {
        protected AttackItems(int attack)
        {
            this.Attack = attack;
        }

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
    }
}