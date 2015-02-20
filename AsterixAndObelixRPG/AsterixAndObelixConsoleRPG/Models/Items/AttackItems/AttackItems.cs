﻿namespace AsterixAndObelixConsoleRPG.Models.Items.AttackItems
{
    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;
    using AsterixAndObelixConsoleRPG.Models.Fields;

    public abstract class AttackItems : Item, IAttack
    {
        private int attack;

        protected AttackItems(int attack, int price, ItemType itemType)
            : base(price, itemType)
        {
            this.Attack = attack;
        }

        public int Attack
        {
            get
            {
                return this.attack;
            }

            set
            {
                Validator.CheckForNegativeNumber(value);
                this.attack = value;
            }
        }

        public void MakeAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}