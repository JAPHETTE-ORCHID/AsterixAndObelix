using AsterixAndObelixConsoleRPG.Enumerations;

namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class Sword : AttackItems
    {
        public Sword(int price, ItemType itemType, int attack)
            : base(attack)
        {
            this.ItemType = itemType;
            this.Price = price;
        }
    }
}