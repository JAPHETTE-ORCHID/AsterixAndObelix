using AsterixAndObelixConsoleRPG.Contracts;
using AsterixAndObelixConsoleRPG.Enumerations;
namespace AsterixAndObelixConsoleRPG.Models.Items.UniqueItem
{
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
