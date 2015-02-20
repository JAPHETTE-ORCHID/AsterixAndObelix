namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using System;

    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;
    using AsterixAndObelixConsoleRPG.Models.Items;

    public class Enemy : PlayerObject, IDrop
    {
        public Enemy(int attack, int defence, int health, EnemyType enemyType, int gold)
            : base(attack, defence, health)
        {
            this.EnemyType = enemyType;
            this.Gold = gold;
        }

        public EnemyType EnemyType { get; set; }

        public int Gold { get; set; }

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
                            itemForDrop = new Belt(10, 10, ItemType.Common);
                            break;
                        case 2:
                            itemForDrop = new Boots(10, 10, ItemType.Common);
                            break;
                        case 3:
                            itemForDrop = new Chest(10, 10, ItemType.Common);
                            break;
                        case 4:
                            itemForDrop = new Helmet(10, 10, ItemType.Common);
                            break;
                        case 5:
                            itemForDrop = new Pants(10, 10, ItemType.Common);
                            break;
                        case 6:
                            itemForDrop = new Sword(10, 10, ItemType.Common);
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
                            itemForDrop = new Belt(50, 50, ItemType.Uncommon);
                            break;
                        case 2:
                            itemForDrop = new Boots(50, 50, ItemType.Uncommon);
                            break;
                        case 3:
                            itemForDrop = new Chest(50, 50, ItemType.Uncommon);
                            break;
                        case 4:
                            itemForDrop = new Helmet(50, 50, ItemType.Uncommon);
                            break;
                        case 5:
                            itemForDrop = new Pants(50, 50, ItemType.Uncommon);
                            break;
                        case 6:
                            itemForDrop = new Sword(50, 50, ItemType.Uncommon);
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
                            itemForDrop = new Belt(100, 100, ItemType.Rare);
                            break;
                        case 2:
                            itemForDrop = new Boots(100, 100, ItemType.Rare);
                            break;
                        case 3:
                            itemForDrop = new Chest(100, 100, ItemType.Rare);
                            break;
                        case 4:
                            itemForDrop = new Helmet(100, 100, ItemType.Rare);
                            break;
                        case 5:
                            itemForDrop = new Pants(100, 100, ItemType.Rare);
                            break;
                        case 6:
                            itemForDrop = new Sword(100, 100, ItemType.Rare);
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
                            itemForDrop = new Belt(150, 150, ItemType.Magic);
                            break;
                        case 2:
                            itemForDrop = new Boots(150, 150, ItemType.Magic);
                            break;
                        case 3:
                            itemForDrop = new Chest(150, 150, ItemType.Magic);
                            break;
                        case 4:
                            itemForDrop = new Helmet(150, 150, ItemType.Magic);
                            break;
                        case 5:
                            itemForDrop = new Pants(150, 150, ItemType.Magic);
                            break;
                        case 6:
                            itemForDrop = new Sword(150, 150, ItemType.Magic);
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
                            itemForDrop = new Belt(200, 200, ItemType.Legendary);
                            break;
                        case 2:
                            itemForDrop = new Boots(200, 200, ItemType.Legendary);
                            break;
                        case 3:
                            itemForDrop = new Chest(200, 200, ItemType.Legendary);
                            break;
                        case 4:
                            itemForDrop = new Helmet(200, 200, ItemType.Legendary);
                            break;
                        case 5:
                            itemForDrop = new Pants(200, 200, ItemType.Legendary);
                            break;
                        case 6:
                            itemForDrop = new Sword(200, 200, ItemType.Legendary);
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

        public override string ToString()
        {
            return string.Format("{0}:\nGold: {1} Attack: {2} Defence: {3} Health: {4}", this.EnemyType, this.Gold, this.Attack, this.Defence, this.Health);
        }
    }
}