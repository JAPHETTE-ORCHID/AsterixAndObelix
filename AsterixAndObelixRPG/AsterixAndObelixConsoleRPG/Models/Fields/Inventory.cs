﻿namespace AsterixAndObelixConsoleRPG.Models.Fields
{
    using System.Collections.Generic;

    using Contracts;

    public class Inventory
    {
        private List<IItem> items = new List<IItem>();

        public List<IItem> Items
        {
            get
            {
                return this.items;
            }

            set
            {
                this.items = value;
            }
        }

        public void AddItem(IItem item)
        {
            Validator.CheckForNullItem(item);
            BattleField.Hero.addPowerFromItem(item);
            this.Items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            Validator.CheckForNullItem(item);
            this.Items.Remove(item);
        }

        public override string ToString()
        {
            string inventoryInfo = string.Join(" ", this.Items);

            return inventoryInfo;
        }
    }
}