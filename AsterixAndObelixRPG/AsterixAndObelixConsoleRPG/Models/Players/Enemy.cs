namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using System;
    using System.Collections.Generic;

    using AsterixAndObelixConsoleRPG.Models.Items;
    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;

    internal class Enemy : PlayerObject, IDrop
    {
        public Enemy(int attack, int defence, int health, EnemyType enemyType, int gold, List<IItem> itemsForDrop )
            : base(attack, defence, health)
        {
            this.EnemyType = enemyType;
            this.Gold = gold;
            this.ItemsForDrop = itemsForDrop;
        }

        public EnemyType EnemyType { get; set; }

        public int Gold { get; set; }

        public List<IItem> ItemsForDrop { get; set; }

        public IItem DropRandomItem()
        {
            Random rnd = new Random();
            int itemNumber = rnd.Next(1, 6);
            IItem itemForDrop;
            switch (this.EnemyType)
            {
                case EnemyType.Cadet:
                    switch (itemNumber)
                    {
                        case 1:
                            itemForDrop = new Belt(10, ItemType.Common, 10);
                            break;
                        case 2:
                            itemForDrop = new Boots(10, ItemType.Common, 10);
                            break;
                        case 3:
                            itemForDrop = new Chest(10, ItemType.Common, 10);
                            break;
                        case 4:
                            itemForDrop = new Helmet(10, ItemType.Common, 10);
                            break;
                        case 5:
                            itemForDrop = new Pants(10, ItemType.Common, 10);
                            break;
                        case 6:
                            itemForDrop = new Sword(10, ItemType.Common, 10);
                            break;
                        default:
                            itemForDrop = null;
                            break;                        
                    }
                    break;
                case EnemyType.Manipularius:
                    switch (itemNumber)
                    {
                        case 1:
                            itemForDrop = new Belt(50, ItemType.Uncommon, 50);
                            break;
                        case 2:
                            itemForDrop = new Boots(50, ItemType.Uncommon, 50);
                            break;
                        case 3:
                            itemForDrop = new Chest(50, ItemType.Uncommon, 50);
                            break;
                        case 4:
                            itemForDrop = new Helmet(50, ItemType.Uncommon, 50);
                            break;
                        case 5:
                            itemForDrop = new Pants(50, ItemType.Uncommon, 50);
                            break;
                        case 6:
                            itemForDrop = new Sword(50, ItemType.Uncommon, 50);
                            break;
                        default:
                            itemForDrop = null;
                            break;
                    }
                    break;
                case EnemyType.Centurion:
                    switch (itemNumber)
                    {
                        case 1:
                            itemForDrop = new Belt(100, ItemType.Rare, 100);
                            break;
                        case 2:
                            itemForDrop = new Boots(100, ItemType.Rare, 100);
                            break;
                        case 3:
                            itemForDrop = new Chest(100, ItemType.Rare, 100);
                            break;
                        case 4:
                            itemForDrop = new Helmet(100, ItemType.Rare, 100);
                            break;
                        case 5:
                            itemForDrop = new Pants(100, ItemType.Rare, 100);
                            break;
                        case 6:
                            itemForDrop = new Sword(100, ItemType.Rare, 100);
                            break;
                        default:
                            itemForDrop = null;
                            break;
                    }
                    break;
                case EnemyType.Tribune:
                    switch (itemNumber)
                    {
                        case 1:
                            itemForDrop = new Belt(150, ItemType.Magic, 150);
                            break;
                        case 2:
                            itemForDrop = new Boots(150, ItemType.Magic, 150);
                            break;
                        case 3:
                            itemForDrop = new Chest(150, ItemType.Magic, 150);
                            break;
                        case 4:
                            itemForDrop = new Helmet(150, ItemType.Magic, 150);
                            break;
                        case 5:
                            itemForDrop = new Pants(150, ItemType.Magic, 150);
                            break;
                        case 6:
                            itemForDrop = new Sword(150, ItemType.Magic, 150);
                            break;
                        default:
                            itemForDrop = null;
                            break;
                    }
                    break;
                case EnemyType.Caesar:
                    switch (itemNumber)
                    {
                        case 1:
                            itemForDrop = new Belt(200, ItemType.Legendary, 200);
                            break;
                        case 2:
                            itemForDrop = new Boots(200, ItemType.Legendary, 200);
                            break;
                        case 3:
                            itemForDrop = new Chest(200, ItemType.Legendary, 200);
                            break;
                        case 4:
                            itemForDrop = new Helmet(200, ItemType.Legendary, 200);
                            break;
                        case 5:
                            itemForDrop = new Pants(200, ItemType.Legendary, 200);
                            break;
                        case 6:
                            itemForDrop = new Sword(200, ItemType.Legendary, 200);
                            break;
                        default:
                            itemForDrop = null;
                            break;
                    }
                    break;
                default:
                    itemForDrop = null;
                    break;
            }
            return itemForDrop;
        }

        public int DropGold()
        {
            return this.Gold;
        }
    }
}