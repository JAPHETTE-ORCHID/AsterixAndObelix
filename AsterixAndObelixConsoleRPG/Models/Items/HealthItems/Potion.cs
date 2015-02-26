namespace AsterixAndObelixConsoleRPG.Models.Items.HealthItems
{
    using Contracts;
    using Enumerations;
    using Fields;

    internal class Potion : Item, IHeal
    {
        public Potion(ItemType itemType)
            : base(itemType)
        {
        }
        public int Health { get; set; }

        public void Heal()
        {
            if (this.ItemType.Equals(ItemType.Common))
            {
                BattleField.Hero.Health += 20;
                this.Health = 20;
            }
            else if (this.ItemType.Equals(ItemType.Uncommon))
            {
                BattleField.Hero.Health += 40;
                this.Health = 40;
            }
            else if (this.ItemType.Equals(ItemType.Rare))
            {
                BattleField.Hero.Health += 60;
                this.Health = 60;
            }
            else if (this.ItemType.Equals(ItemType.Magic))
            {
                BattleField.Hero.Health += 80;
                this.Health = 80;
            }
            else if (this.ItemType.Equals(ItemType.Legendary))
            {
                BattleField.Hero.Health += 100;
                this.Health = 100;
            }
        }
    }
}
