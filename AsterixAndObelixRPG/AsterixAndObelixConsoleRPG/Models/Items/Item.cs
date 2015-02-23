namespace AsterixAndObelixConsoleRPG.Models.Items
{
    using System.Linq;
    using System.Text;

    using Calculator;
    using Contracts;
    using Enumerations; 
    using Fields;

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

        public static bool IsItemBetter(IItem input)
        {
            return Field.Hero.Inventory.Items.Where(item => item.GetType().Name == input.GetType().Name).Any(item => (int) input.ItemType > (int) item.ItemType);
        }

        public static void GetBetterItem(IItem newItem)
        {
            IItem weakItem = null;
            bool hasInventoryItem = false;
            foreach (var item in Field.Hero.Inventory.Items)
            {
                if (item.GetType().Name == newItem.GetType().Name)
                {
                    hasInventoryItem = true;
                    if ((int)newItem.ItemType > (int)item.ItemType)
                    {
                        weakItem = item;
                    }
                }
            }

            if (weakItem != null)
            {
                Field.Hero.Inventory.RemoveItem(weakItem);
                hasInventoryItem = false;
            }

            if (!hasInventoryItem)
            {
                Field.Hero.Inventory.AddItem(newItem);
            }
        }

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