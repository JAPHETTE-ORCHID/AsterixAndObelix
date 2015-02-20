namespace AsterixAndObelixConsoleRPG.Models.Items
{
    using AsterixAndObelixConsoleRPG.Enumerations;

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