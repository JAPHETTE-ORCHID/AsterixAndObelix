using AsterixAndObelixConsoleRPG.Enumerations;
namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class Helmet : DefenseItems
    {
        public Helmet(int defence, int price, ItemType itemType) 
            : base(defence, price, itemType)
        {
            this.Price = price;
            this.ItemType = itemType;
        }
    }
}