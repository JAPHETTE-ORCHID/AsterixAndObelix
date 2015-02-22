namespace AsterixAndObelixConsoleRPG.Models.Items.AttackItems
{
    using Enumerations;

    public class Boots : AttackItem
    {    
        private const int DefaultAttack = 100;
        private const decimal DefaultPrice = 100m;
        private const ItemType DefaultType = ItemType.Common;

        public Boots(ItemType itemType = DefaultType)
            : base(DefaultAttack, DefaultPrice, itemType)
        {
        }
    }
}