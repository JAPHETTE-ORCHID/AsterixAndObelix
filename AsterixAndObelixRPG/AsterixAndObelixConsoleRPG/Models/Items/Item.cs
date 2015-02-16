namespace AsterixAndObelixConsoleRPG.Models.Items
{
    using System;
    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;
    using AsterixAndObelixConsoleRPG.Models.Fields;

    public abstract class Item : IItem
    {
        private int price;
        private ItemType itemType;
        protected Item(int price, ItemType itemType)
        {
            this.Price = price;
            this.ItemType = itemType;
        }

        public int Price
        {
            get
            {
                return this.price;
            }

            set
            {
                Validator.CheckForNegativeNumber(value);
                this.price = value;
            }
        }

        public ItemType ItemType
        {
            get
            {
                return this.itemType;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Text field cannot be null.")
                };
                this.itemType = value;
            }
        }
    }
}