using Constants = AsterixAndObelixConsoleRPG.Models.Fields.Constants;

namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using AsterixAndObelixConsoleRPG.Models.Fields;
    using AsterixAndObelixConsoleRPG.Contracts;

    public abstract class Hero : PlayerObject, IInventory
    {
        private int experience;
        private int gold;
        private string name;
        private Inventory inventory;

        public Hero(string name, int attack, int defence, int health)
            : base(attack, defence, health)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckForEmptyOrNull(value);
                this.name = value;
            }
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

        public int Level
        {
            get
            {
                int level = (this.experience / Constants.ExpPerLevel) + 1;

                return level;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return this.inventory;
            }

            set
            {
                Validator.CheckForNullInventory(value);
                this.Inventory = value;
            }
        }

        public void AddItem(IItem item)
        {
            this.Inventory.AddItem(item);
        }

        public void RemoveItem(IItem item)
        {
            this.Inventory.RemoveItem(item);
        }

        public string ShowItems()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Items: ")
                  .Append(string.Join(", ", this.Inventory));

            return result.ToString();
        }

        public override string ToString()
        {
            string heroInfo = "Hero name: "+this.name;

            return heroInfo;
        }
    }
}