namespace AsterixAndObelixConsoleRPG.Models.Items.AttackItems
{
    using AsterixAndObelixConsoleRPG.Enumerations;

    public class Sword : AttackItem
    {
        private const int DefaultAttack = 100;
        private const decimal DefaultPrice = 100m;
        private const ItemType DefaultType = ItemType.Common;

        public Sword(ItemType itemType = DefaultType)
            : base(DefaultAttack, DefaultPrice, itemType)
        {
        }
    }
}