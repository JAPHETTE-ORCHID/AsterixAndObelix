namespace AsterixAndObelixConsoleRPG.Models.Items.DefenseItems
{
    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;
    using AsterixAndObelixConsoleRPG.Models.Calculator;
    using AsterixAndObelixConsoleRPG.Models.Fields;
    using System.Text;

    public abstract class DefenseItem : Item, IDefence
    {
        private int defence;

        protected DefenseItem(int defence, decimal price, ItemType itemType)
            : base(price, itemType)
        {
            this.Defence = defence;
        }

        public int Defence 
        {
            get
            {
                int defence = (int)ItemTypeCalculator.CalculateByItemType(this.ItemType, this.defence);
                return defence;
            }

            set
            {
                Validator.CheckForNegativeNumber(value);
                this.defence = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            result.Append("  Defence: ").AppendLine(this.Defence.ToString());

            return result.ToString();
        }
    }
}