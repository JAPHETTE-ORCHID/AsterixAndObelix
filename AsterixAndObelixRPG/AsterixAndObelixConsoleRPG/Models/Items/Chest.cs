using AsterixAndObelixConsoleRPG.Enumerations;

namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class Chest : DefenseItems
    {
        public Chest(int defence, int price, ItemType itemType) 
            : base(defence, price, itemType)
        {
            this.Price = price;
            this.ItemType = itemType;
        }
    }
}