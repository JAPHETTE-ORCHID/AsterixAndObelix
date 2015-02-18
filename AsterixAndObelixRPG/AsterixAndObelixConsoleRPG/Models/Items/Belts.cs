using AsterixAndObelixConsoleRPG.Enumerations;
namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class Belt : AttackItems
    {
        public Belt(int attack, ItemType itemType, int price)
            : base(attack, price, itemType)
        {
            this.Attack = attack;
        }
    }
}