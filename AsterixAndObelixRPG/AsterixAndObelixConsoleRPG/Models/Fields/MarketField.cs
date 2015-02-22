namespace AsterixAndObelixConsoleRPG.Models.Fields
{
    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;
    using AsterixAndObelixConsoleRPG.Models.Calculator;
    using AsterixAndObelixConsoleRPG.Models.Items;
    using AsterixAndObelixConsoleRPG.Models.Items.AttackItems;
    using AsterixAndObelixConsoleRPG.Models.Items.DefenseItems;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: The market where hero can buy items
    /// </summary>
    public class MarketField : Field
    {
        private Operation operation;
        private IList itemTypes;
        private ItemType itemType;
        private List<Item> items;

        public MarketField()
        {
            itemTypes = Enum.GetValues(typeof(ItemType));
        }

        public void PrintAllItemTypes()
        {
            for (int i = 0; i < itemTypes.Count; i++)
            {
                Console.WriteLine("{0}. {1}", (i + 1), itemTypes[i]);
            }

            this.operation = Operation.ChoosingItemType;
        }

        public void ReadCommand()
        {
            int command = 0;
            try
            {
                command = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Enter a number.");
            }

            if (operation == Operation.ChoosingItemType)
            {
                if (command < 1 || command > itemTypes.Count)
                {
                    throw new Exception("Invalid item type.");
                }
                
                int index = command - 1;
                this.itemType = (ItemType)index;

                loadAllItems();
                PrintAllItems();
            }
            else if (operation == Operation.ChoosingItem)
            {
                if (command < 1 || command > items.Count)
                {
                    throw new Exception("Invalid item id.");
                }
                int index = command - 1;

                if (BattleField.Hero == null)
                {
                    throw new Exception("First you must add a hero.");
                }

                BattleField.Hero.Inventory.AddItem(this.items[index]);
                Console.WriteLine("Item was added to your inventory.");
            }
        }

        public void PrintAllItems()
        {
            if (this.items == null)
            {
                Console.WriteLine("No laoded items.");
                return;
            }

            Console.WriteLine("{0} items: ", this.itemType.ToString());
            int itemCount = 0;
            const int cellWidth = 10;
            char paddingChar = '-';
            Console.WriteLine(
                "Buy Id".PadRight(cellWidth) +
                "Name".PadRight(cellWidth) +
                "Defence".PadRight(cellWidth) + 
                "Attack".PadRight(cellWidth) +
                "Price".PadRight(cellWidth)
                );
            StringBuilder itemList = new StringBuilder();
            foreach (var item in this.items)
            {
                itemCount++;
                itemList.Append(itemCount.ToString().PadRight(cellWidth, paddingChar));
                itemList.Append(item.GetType().Name.PadRight(cellWidth, paddingChar));
                if (item is AttackItem)
                {
                    itemList.Append("0".PadRight(cellWidth, paddingChar));
                    itemList.Append(((AttackItem)item).Attack.ToString().PadRight(cellWidth, paddingChar));
                }
                else
                {
                    itemList.Append(((DefenseItem)item).Defence.ToString().PadRight(cellWidth, paddingChar));
                    itemList.Append("0".PadRight(cellWidth, paddingChar));
                }

                itemList.Append(item.Price.ToString());
                itemList.AppendLine();
            }

            Console.WriteLine(itemList.ToString());
            this.operation = Operation.ChoosingItem;
            this.ReadCommand();
        }

        public void loadAllItems()
        {
            items = new List<Item>()
            {
                new Belt(this.itemType),
                new Boots(this.itemType),
                new Sword(this.itemType),
                new Chest(this.itemType),
                new Helmet(this.itemType),
                new Pants(this.itemType)
                
            };
        }
    }
}