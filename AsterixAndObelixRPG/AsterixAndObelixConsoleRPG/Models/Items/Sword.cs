using AsterixAndObelixConsoleRPG.Enumerations;

namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class Sword : AttackItems
    {
        public Sword(int attack, int price, ItemType itemType)
            : base(attack, price, itemType)
        {
            this.ItemType = itemType;
            this.Price = price;
        }
    }
}