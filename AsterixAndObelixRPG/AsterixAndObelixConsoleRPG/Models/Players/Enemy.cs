using AsterixAndObelixConsoleRPG.Models.Items;

namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using System;
    using System.Collections.Generic;

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
                            itemForDrop = new Belt(100, ItemType.Common, 100);
                            break;
                        case 2:
                            itemForDrop = new Boots(100, ItemType.Common, 100);
                            break;
                        case 3:
                            itemForDrop = new Chest(100, ItemType.Common, 100);
                            break;
                        case 4:
                            itemForDrop = new Helmet(100, ItemType.Common, 100);
                            break;
                        case 5:
                            itemForDrop = new Pants(100, ItemType.Common, 100);
                            break;
                        case 6:
                            itemForDrop = new Sword(100, ItemType.Common, 100);
                            break;
                        default:
                            itemForDrop = null;
                            break;
                            
                    }
                    break;
                default:
                    itemForDrop = new Sword(100, ItemType.Common, 100);
                    break;
            }
            return itemForDrop;
        }

        public int DropGold()
        {
            return this.Gold;
        }

        IItem IDrop.DropRandomItem()
        {
            throw new System.NotImplementedException();
        }

        int IDrop.DropGold()
        {
            throw new System.NotImplementedException();
        }
    }
}