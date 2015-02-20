namespace AsterixAndObelixConsoleRPG.Models.Items.AttackItems
{
    using AsterixAndObelixConsoleRPG.Enumerations;

    public class Belt : AttackItems
    {
        public Belt(int attack, int price, ItemType itemType)
            : base(attack, price, itemType)
        {
            this.Attack = attack;
        }
    }
}