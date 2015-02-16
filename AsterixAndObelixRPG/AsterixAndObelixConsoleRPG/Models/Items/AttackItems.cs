using AsterixAndObelixConsoleRPG.Contracts;
using AsterixAndObelixConsoleRPG.Enumerations;

namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class AttackItems : Item, IAttack
    {
        protected AttackItems(int attack, int price, ItemType itemType)
            : base(price, itemType)
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


        public void MakeAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}