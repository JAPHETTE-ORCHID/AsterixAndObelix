namespace AsterixAndObelixConsoleRPG.Models.Items.DefenseItems
{
    using AsterixAndObelixConsoleRPG.Enumerations;

    public class Pants : DefenseItems
    {
        public Pants(int defence, int price, ItemType itemType)
            : base(defence, price, itemType)
        {
            this.Price = price;
            this.ItemType = itemType;
        }
    }
}