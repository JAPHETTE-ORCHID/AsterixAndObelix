namespace AsterixAndObelixConsoleRPG.Models.Items.DefenseItems
{
    using Enumerations;

    public class Chest : DefenseItem
    {    
        private const int DefaultDefence = 100;
        private const decimal DefaultPrice = 100m;
        private const ItemType DefaultType = ItemType.Common;

        public Chest(ItemType itemType = DefaultType)
            : base(DefaultDefence, DefaultPrice, itemType)
        {
        }
    }
}