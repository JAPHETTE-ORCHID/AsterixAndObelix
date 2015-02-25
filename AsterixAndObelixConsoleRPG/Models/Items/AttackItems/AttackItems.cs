namespace AsterixAndObelixConsoleRPG.Models.Items.AttackItems
{
    using System.Text;
    using Calculator;
    using Enumerations;
    using Fields;

    public abstract class AttackItem : Item
    {
        private int attack;

        protected AttackItem(ItemType itemType)
            : base(itemType)
        {
            this.Attack = attack;
        }

        public int Attack
        {
            get
            {
                int attack = (int)ItemTypeCalculator.CalculateByItemType(this.ItemType, this.attack);
                return attack;
            }

            set
            {
                Validator.CheckForNegativeNumber(value);
                this.attack = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            result.Append("  Attack: ").AppendLine(this.Attack.ToString());

            return result.ToString();
        }

        public override int GetHashCode()
        {
            int hash = base.GetHashCode();

            hash = hash * 23 + this.Attack.GetHashCode();

            return hash;
        }
    }
}