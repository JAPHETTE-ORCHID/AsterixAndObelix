namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using System.Text;

    using Contracts;
    using Fields;
    using Items.AttackItems;
    using Items.DefenseItems;
    using Items.UniqueItem;

    public abstract class Hero : PlayerObject
    {
        private int experience;
        private int gold;
        private Inventory inventory;

        protected Hero(int attack, int defence, int health)
            : base(attack, defence, health)
        {
            this.inventory = new Inventory();
            this.Level = 1;
        }

        public int Experience
        {
            get
            {
                return this.experience;
            }

            set
            {
                Validator.CheckForNegativeNumber(value);
                this.experience = value;
            }
        }

        public int Gold
        {
            get
            {
                return this.gold;
            }

            set
            {
                Validator.CheckForNegativeNumber(value);
                this.gold = value;
            }
        }

        public int Level { get; set; }

        public Inventory Inventory
        {
            get
            {
                return this.inventory;
            }

            set
            {
                Validator.CheckForNullInventory(value);
                this.inventory = value;
            }
        }

        public string ShowItems()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Items: ")
                  .Append(string.Join(", ", this.Inventory));

            return result.ToString();
        }

        public void AddPowerFromItem(IItem item)
        {
            if (item is DefenseItem)
            {
                this.Defence += ((DefenseItem)item).Defence;
            }
            else if (item is AttackItem)
            {
                this.Attack += ((AttackItem)item).Attack;
            }
            else if (item is DefenceAttack)
            {
                this.Attack += ((DefenceAttack)item).Attack;
                this.Defence += ((DefenceAttack)item).Defence;
            }
        }

        public void RemovePowerFromItem(IItem item)
        {
            if (item is DefenseItem)
            {
                this.Defence -= ((DefenseItem)item).Defence;
            }
            else if (item is AttackItem)
            {
                this.Attack -= ((AttackItem)item).Attack;
            }
        }

        public override int MakeAttack()
        {
            int damage = this.Attack - BattleField.TargetEnemy.Defence;
            if (damage <= 0)
            {
                damage = 1;
            }

            return damage;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Hero: ").AppendLine(this.GetType().Name);
            result.Append("Level: ").AppendLine(this.Level.ToString());
            result.Append("Experience: ").AppendLine(this.Experience.ToString());
            result.Append("Gold: ").AppendLine(this.Gold.ToString());
            result.Append("Attack: ").AppendLine(this.Attack.ToString());
            result.Append("Defence: ").AppendLine(this.Defence.ToString());
            result.Append("Health: ").AppendLine(this.Health.ToString());
            result.Append("Inventory: ");
            if (this.Inventory.Items.Count > 0)
            {
                result.AppendLine();
                this.Inventory.Items.ForEach(i => result.AppendLine(i.ToString()));
            }
            else
            {
                result.AppendLine("No items.");
            }

            return result.ToString();
        }
    }
}