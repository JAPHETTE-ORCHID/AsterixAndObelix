namespace AsterixAndObelixConsoleRPG.Models.Fields
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using Interafaces;
    using Enumerations;
    using Items;
    using Items.AttackItems;
    using Items.DefenseItems;
    using Items.HealthItems;
    using Items.UniqueItem;

    public class MarketField : Field
    {
        private Operation operation;
        private IList itemTypes;
        private ItemType itemType;
        private List<Item> items;

        public MarketField()
        {
            this.itemTypes = Enum.GetValues(typeof(ItemType));
        }

        public void PrintAllItemTypes()
        {
            Validator.CheckIfHeroExist(Field.Hero);
            for (int i = 0; i < this.itemTypes.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, this.itemTypes[i]);
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
            catch (Exception)
            {
                Console.WriteLine("Enter a number.");
            }

            if (this.operation == Operation.ChoosingItemType)
            {
                if (command < 1 || command > this.itemTypes.Count)
                {
                    throw new Exception("Invalid item type.");
                }
                
                int index = command - 1;
                this.itemType = (ItemType)index;

                this.LoadAllItems();
                this.PrintAllItems();
            }
            else if (this.operation == Operation.ChoosingItem)
            {
                if (command < 1 || command > this.items.Count)
                {
                    throw new Exception("Invalid item id.");
                }

                int index = command - 1;

                if (Hero.Gold < this.items[index].Price)
                {
                    throw new Exception("You don't have enough money.");
                }

                Hero.Gold -= this.items[index].Price;
                
                Potion potion = this.items[index] as Potion;
                if (potion != null)
                {
                    potion.Heal();
                    Console.WriteLine("+" + potion.Health + " health.");
                }
                else
                {
                    Hero.Inventory.AddItem(this.items[index]);
                    Console.WriteLine("Item was added to your inventory.");
                }
            }
        }

        public void PrintAllItems()
        {
            if (this.items == null)
            {
                Console.WriteLine("No laoded items.");
                return;
            }

            Console.WriteLine("{0} items: ", this.itemType);
            int itemCount = 0;
            const int CellWidth = 10;
            char paddingChar = '-';
            Console.WriteLine(
                "Buy Id".PadRight(CellWidth) +
                "Name".PadRight(CellWidth) +
                "Defence".PadRight(CellWidth) +
                "Attack".PadRight(CellWidth) +
                "Health".PadRight(CellWidth) +
                "Price".PadRight(CellWidth));

            StringBuilder itemList = new StringBuilder();
            foreach (var item in this.items)
            {
                itemCount++;
                itemList.Append(itemCount.ToString().PadRight(CellWidth, paddingChar));
                itemList.Append(item.GetType().Name.PadRight(CellWidth, paddingChar));
                if (item is AttackItem)
                {
                    itemList.Append("0".PadRight(CellWidth, paddingChar));
                    itemList.Append(((AttackItem)item).Attack.ToString().PadRight(CellWidth, paddingChar));
                    itemList.Append("0".PadRight(CellWidth, paddingChar));
                }
                else if (item is DefenseItem)
                {
                    itemList.Append(((DefenseItem)item).Defence.ToString().PadRight(CellWidth, paddingChar));
                    itemList.Append("0".PadRight(CellWidth, paddingChar));
                    itemList.Append("0".PadRight(CellWidth, paddingChar));
                }
                else if (item is DefenceAttack)
                {
                    itemList.Append(((DefenceAttack)item).Defence.ToString().PadRight(CellWidth, paddingChar));
                    itemList.Append(((DefenceAttack)item).Attack.ToString().PadRight(CellWidth, paddingChar));
                    itemList.Append("0".PadRight(CellWidth, paddingChar));
                }
                else if (item is IHeal)
                {
                    itemList.Append("0".PadRight(CellWidth, paddingChar));
                    itemList.Append("0".PadRight(CellWidth, paddingChar));
                    itemList.Append(((IHeal)item).Health.ToString().PadRight(CellWidth, paddingChar));
                }

                itemList.Append(item.Price.ToString());
                itemList.AppendLine();
            }

            Console.WriteLine(itemList.ToString());
            this.operation = Operation.ChoosingItem;
            this.ReadCommand();
        }
        
        public void LoadAllItems()
        {
            this.items = new List<Item>()
            {
                new Belt(this.itemType),
                new Boots(this.itemType),
                new Sword(this.itemType),
                new Chest(this.itemType),
                new Helmet(this.itemType),
                new Pants(this.itemType),
                new Potion(this.itemType)
            };

            for (int heroItemIndex = 0; heroItemIndex < BattleField.Hero.Inventory.Items.Count; heroItemIndex++)
            {
                for (int itemIndex = 0; itemIndex < this.items.Count; itemIndex++)
                {
                    var heroItem = BattleField.Hero.Inventory.Items[heroItemIndex];
                    var item = this.items[itemIndex];
                    if (heroItem.Equals(item))
                    {
                        this.items.RemoveAt(itemIndex);
                    }
                }
            }
        }
    }
}