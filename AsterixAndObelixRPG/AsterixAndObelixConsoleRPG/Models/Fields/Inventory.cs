namespace AsterixAndObelixConsoleRPG.Models.Fields
{
    using System;
    using System.Collections.Generic;
    using AsterixAndObelixConsoleRPG.Contracts;

    public class Inventory
    {
        List<IItem> Items { get; set; }

        public void AddItem(IItem item)
        {
            Validator.CheckForNullItem(item);
            this.Items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            Validator.CheckForNullItem(item);
            this.Items.Remove(item);
        }
    }
}