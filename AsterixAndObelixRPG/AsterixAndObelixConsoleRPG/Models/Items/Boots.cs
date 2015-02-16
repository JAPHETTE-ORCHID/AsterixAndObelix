using AsterixAndObelixConsoleRPG.Enumerations;
namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class Boots : AttackItems
    {
        public Boots(int price, ItemType itemType, int attack)
            : base(attack)
        {
            this.Price = price;
            this.ItemType = itemType;
        }
    }
}