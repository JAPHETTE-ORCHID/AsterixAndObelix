using AsterixAndObelixConsoleRPG.Enumerations;

namespace AsterixAndObelixConsoleRPG.Models.Items
{
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