namespace AsterixAndObelixConsoleRPG.Models.Items.UniqueItem
{
    using Enumerations;

    public abstract class DefenceAttack : Item
    {
        protected DefenceAttack(ItemType itemType)
            : base(itemType)
        {
        }

        public abstract int Attack { get; }

        public abstract int Defence { get; }
    }
}
