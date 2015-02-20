namespace AsterixAndObelixConsoleRPG.Models.Items
{
    using AsterixAndObelixConsoleRPG.Enumerations;

    public class Boots : AttackItems
    {
        public Boots(int attack, int price, ItemType itemType)
            : base(attack, price, itemType)
        {
            this.Price = price;
            this.ItemType = itemType;
        }
    }
}