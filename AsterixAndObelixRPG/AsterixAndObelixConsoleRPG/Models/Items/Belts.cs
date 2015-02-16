using AsterixAndObelixConsoleRPG.Enumerations;
namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class Belt : AttackItems
    {
        public Belt(int price, ItemType itemType, int attack)
            : base(attack)
        {
            this.Price = price;
            this.ItemType = itemType;
        }
    }
}