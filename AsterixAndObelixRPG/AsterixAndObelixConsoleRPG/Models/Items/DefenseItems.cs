namespace AsterixAndObelixConsoleRPG.Models.Items
{
    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;
    using AsterixAndObelixConsoleRPG.Models.Fields;

    public class DefenseItems : Item, IDefence
    {
        private int defence;

        public DefenseItems(int defence, int price, ItemType itemType) 
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