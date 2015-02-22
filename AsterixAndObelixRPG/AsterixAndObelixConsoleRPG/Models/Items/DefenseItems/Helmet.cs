namespace AsterixAndObelixConsoleRPG.Models.Items.DefenseItems
{
    using Enumerations;

    public class Helmet : DefenseItem
    {
        private const int DefaultDefence = 100;
        private const decimal DefaultPrice = 100m;
        private const ItemType DefaultType = ItemType.Common;

        public Helmet(ItemType itemType = DefaultType)
            : base(DefaultDefence, DefaultPrice, itemType)
        {
        }
    }
}