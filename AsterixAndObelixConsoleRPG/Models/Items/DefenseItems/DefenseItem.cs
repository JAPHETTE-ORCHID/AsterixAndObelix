namespace AsterixAndObelixConsoleRPG.Models.Items.DefenseItems
{
    using System.Text;

    using Calculator;
    using Contracts;
    using Enumerations;    
    using Fields;

    public abstract class DefenseItem : Item, IDefence
    {
        protected DefenseItem(ItemType itemType)
            : base(itemType)
        {
        }

        public abstract int Defence { get; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            result.Append("  Defence: ").AppendLine(this.Defence.ToString());

            return result.ToString();
        }

        public override int GetHashCode()
        {
            int hash = base.GetHashCode();

            hash = (hash * 23) + this.Defence.GetHashCode();

            return hash;
        }
    }
}