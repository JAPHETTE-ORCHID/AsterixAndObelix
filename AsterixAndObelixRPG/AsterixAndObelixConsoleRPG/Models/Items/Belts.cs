using AsterixAndObelixConsoleRPG.Enumerations;
namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class Belt : AttackItems
    {
        public Belt(int attack, int price, ItemType itemType)
            : base(attack, price, itemType)
        {
            this.Attack = attack;
        }
    }
}