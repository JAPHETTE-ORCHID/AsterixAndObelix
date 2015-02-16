using AsterixAndObelixConsoleRPG.Contracts;
using AsterixAndObelixConsoleRPG.Enumerations;
namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class DefenseItems : Item, IDefence
    {
        public DefenseItems(int price, ItemType itemType, int defence) 
            : base (price, itemType)
        {
            this.Price = price;
            this.ItemType = itemType;
            this.Defence = defence;
        }

        public int Defence { get; set; }
    }
}