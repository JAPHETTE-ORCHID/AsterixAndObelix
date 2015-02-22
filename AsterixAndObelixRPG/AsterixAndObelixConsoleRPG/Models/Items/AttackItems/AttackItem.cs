﻿namespace AsterixAndObelixConsoleRPG.Models.Items.AttackItems
{
    using System.Text;

    using Calculator;
    using Enumerations;
    using Fields;

    public abstract class AttackItem : Item
    {
        private int attack;

        protected AttackItem(int attack, decimal price, ItemType itemType)
            : base(price, itemType)
        {
            this.Attack = attack;
        }

        public int Attack
        {
            get
            {
                int attack = (int)ItemTypeCalculator.CalculateByItemType(this.ItemType, this.attack);
                return attack;
            }

            set
            {
                Validator.CheckForNegativeNumber(value);
                this.attack = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString());
            result.Append("  Attack: ").AppendLine(this.Attack.ToString());

            return result.ToString();
        }
    }
}