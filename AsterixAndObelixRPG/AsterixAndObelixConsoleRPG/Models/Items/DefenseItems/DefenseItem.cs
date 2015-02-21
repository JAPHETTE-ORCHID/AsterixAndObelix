namespace AsterixAndObelixConsoleRPG.Models.Items.DefenseItems
{
    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;
    using AsterixAndObelixConsoleRPG.Models.Fields;

    public class DefenseItem : Item, IDefence
    {
        private int defence;

        public DefenseItem(int defence, decimal price, ItemType itemType)
            : base(price, itemType)
        {
            this.Price = price;
            this.ItemType = itemType;
            this.Defence = defence;
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
    }
}