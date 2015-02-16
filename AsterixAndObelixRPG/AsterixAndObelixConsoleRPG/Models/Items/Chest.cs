using AsterixAndObelixConsoleRPG.Enumerations;

namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class Chest : DefenseItems
    {
        public Chest(int price, ItemType itemType, int defence) 
            : base(price, itemType, defence)
        {
            this.Price = price;
            this.ItemType = itemType;
        }
    }
}