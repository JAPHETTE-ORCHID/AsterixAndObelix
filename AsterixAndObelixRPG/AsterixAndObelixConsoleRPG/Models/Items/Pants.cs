using AsterixAndObelixConsoleRPG.Enumerations;

namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class Pants : DefenseItems
    {
        protected Pants(int price, ItemType itemType, int defence) 
            : base(price, itemType, defence)
        {
            this.Price = price;
            this.ItemType = itemType;
        }
    }
}