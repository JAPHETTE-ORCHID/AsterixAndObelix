using AsterixAndObelixConsoleRPG.Contracts;
using AsterixAndObelixConsoleRPG.Models.Fields;

namespace AsterixAndObelixConsoleRPG.Models.Items.HealthItems
{
    using AsterixAndObelixConsoleRPG.Enumerations;

    class Potion : Item, IHeal
    {
        private PotionType potionType;
        private const decimal DefaultPrice = 100m;

        public Potion(ItemType itemType)
            : base(DefaultPrice, itemType)
        {
            this.PotionType = potionType;
        }

        public PotionType PotionType
        {
            get
            {
                return this.potionType;
            }

            set
            {
                this.potionType = value;
            }
        }

        public void Heal()
        {
            if (this.ItemType.Equals(ItemType.Common))
            {
                BattleField.Hero.Health += 20;
            }
            else if (this.ItemType.Equals(ItemType.Uncommon))
            {
                BattleField.Hero.Health += 40;
            }
            else if (this.ItemType.Equals(ItemType.Rare))
            {
                BattleField.Hero.Health += 60;
            }
            else if (this.ItemType.Equals(ItemType.Magic))
            {
                BattleField.Hero.Health += 80;
            }
            else if (this.ItemType.Equals(ItemType.Legendary))
            {
                BattleField.Hero.Health += 100;
            }
        }
    }
}
