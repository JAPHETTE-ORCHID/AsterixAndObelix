using AsterixAndObelixConsoleRPG.Enumerations;
namespace AsterixAndObelixConsoleRPG.Models.Items
{
    public class Belt : AttackItems
    {
        protected Belt(int attack, int price, ItemType itemType)
            : base(attack, price, itemType)
        {
            this.Attack = attack;
        }
    }
}