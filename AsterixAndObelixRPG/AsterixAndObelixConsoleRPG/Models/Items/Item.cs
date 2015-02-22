namespace AsterixAndObelixConsoleRPG.Models.Items
{
    using System.Text;

    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;
    using AsterixAndObelixConsoleRPG.Models.Fields;
    using AsterixAndObelixConsoleRPG.Models.Calculator;

    public abstract class Item : IItem
    {
        private decimal price;

        protected Item(decimal price, ItemType itemType)
        {
            this.Price = price;
            this.ItemType = itemType;
        }

        public decimal Price
        {
            get
            {
                decimal price = ItemTypeCalculator.CalculateByItemType(this.ItemType, this.price);
                return price;
            }

            set
            {
                Validator.CheckForNegativeNumber(value);
                this.price = value;
            }
        }

        public ItemType ItemType { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            string padding = new string(' ', 2);

            result.Append(padding)
                .Append("Item: ")
                .AppendLine(this.GetType().Name);
            result.Append(padding)
                .Append("Item type: ")
                .AppendLine(this.ItemType.ToString());
            result.Append(padding)
                .Append("Item price: ")
                .AppendLine(this.Price.ToString());

            return result.ToString();
        }
    }
}