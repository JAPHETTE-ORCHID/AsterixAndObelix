namespace AsterixAndObelixConsoleRPG.Models.Fields
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
            int sameTypeIndex = this.SameTypeIndex(item);
            if (sameTypeIndex == -1)
            {
                BattleField.Hero.AddPowerFromItem(item);
            }
            else
            {
                this.ReplaceItem(sameTypeIndex, item);
            }

            this.Items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            Validator.CheckForNullItem(item);
            BattleField.Hero.RemovePowerFromItem(item);
            this.Items.Remove(item);
        }

        public void ReplaceItem(int position, IItem item)
        {
            IItem oldItem = this.Items[position];
            BattleField.Hero.RemovePowerFromItem(oldItem);
            this.Items.Remove(oldItem);
            BattleField.Hero.AddPowerFromItem(item);
        }

        public int SameTypeIndex(IItem item)
        {
            foreach (var inventoryItem in this.Items)
            {
                if (inventoryItem.GetType() == item.GetType())
                {
                    return this.Items.IndexOf(inventoryItem);
                }
            }

            return -1;
        }

        public override string ToString()
        {
            string inventoryInfo = string.Join(" ", this.Items);

            return inventoryInfo;
        }
    }
}