namespace AsterixAndObelixConsoleRPG.Models.Items.DefenseItems
{
    using AsterixAndObelixConsoleRPG.Enumerations;

    public class Pants : DefenseItem
    {
        private const int DefaultDefence = 100;
        private const decimal DefaultPrice = 100m;
        private const ItemType DefaultType = ItemType.Common;

        public Pants(ItemType itemType = DefaultType)
            : base(DefaultDefence, DefaultPrice, itemType)
        {
        }
    }
}