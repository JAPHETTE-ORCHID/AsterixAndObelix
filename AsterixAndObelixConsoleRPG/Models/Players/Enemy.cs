namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using System;

    using Interafaces;
    using Enumerations;
    using Fields;
    using Items.AttackItems;
    using Items.DefenseItems;   

    public class Enemy : PlayerObject, IDrop
    {
        private const int DropExpirience = 100;

        public Enemy()            
            : base(0, 0, 0)
        {
        }

        public Enemy(int attack, int defence, int health, EnemyType enemyType, int gold)
            : base(attack, defence, health)
        {
            this.EnemyType = enemyType;
            this.Gold = gold;
        }

        public int Expirience
        {
            get { return Enemy.DropExpirience; }
        }

        public EnemyType EnemyType { get; set; }

        public int Gold { get; set; }

        public IItem DropRandomItem()
        {
            Random rnd = new Random();
            int itemNumber = rnd.Next(1, 7);
            IItem itemForDrop;
            switch (this.EnemyType)
            {
                case EnemyType.Cadet:
                    switch (itemNumber)
                    {
                        case 1:
                            itemForDrop = new Belt();
                            break;
                        case 2:
                            itemForDrop = new Boots();
                            break;
                        case 3:
                            itemForDrop = new Chest();
                            break;
                        case 4:
                            itemForDrop = new Helmet();
                            break;
                        case 5:
                            itemForDrop = new Pants();
                            break;
                        case 6:
                            itemForDrop = new Sword();
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
                            itemForDrop = new Belt(ItemType.Uncommon);
                            break;
                        case 2:
                            itemForDrop = new Boots(ItemType.Uncommon);
                            break;
                        case 3:
                            itemForDrop = new Chest(ItemType.Uncommon);
                            break;
                        case 4:
                            itemForDrop = new Helmet(ItemType.Uncommon);
                            break;
                        case 5:
                            itemForDrop = new Pants(ItemType.Uncommon);
                            break;
                        case 6:
                            itemForDrop = new Sword(ItemType.Uncommon);
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
                            itemForDrop = new Belt(ItemType.Rare);
                            break;
                        case 2:
                            itemForDrop = new Boots(ItemType.Rare);
                            break;
                        case 3:
                            itemForDrop = new Chest(ItemType.Rare);
                            break;
                        case 4:
                            itemForDrop = new Helmet(ItemType.Rare);
                            break;
                        case 5:
                            itemForDrop = new Pants(ItemType.Rare);
                            break;
                        case 6:
                            itemForDrop = new Sword(ItemType.Rare);
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
                            itemForDrop = new Belt(ItemType.Magic);
                            break;
                        case 2:
                            itemForDrop = new Boots(ItemType.Magic);
                            break;
                        case 3:
                            itemForDrop = new Chest(ItemType.Magic);
                            break;
                        case 4:
                            itemForDrop = new Helmet(ItemType.Magic);
                            break;
                        case 5:
                            itemForDrop = new Pants(ItemType.Magic);
                            break;
                        case 6:
                            itemForDrop = new Sword(ItemType.Magic);
                            break;
                        default:
                            itemForDrop = null;
                            break;
                    }

                    break;
                case EnemyType.Ordinatus:
                    switch (itemNumber)
                    {
                        case 1:
                            itemForDrop = new Belt(ItemType.Legendary);
                            break;
                        case 2:
                            itemForDrop = new Boots(ItemType.Legendary);
                            break;
                        case 3:
                            itemForDrop = new Chest(ItemType.Legendary);
                            break;
                        case 4:
                            itemForDrop = new Helmet(ItemType.Legendary);
                            break;
                        case 5:
                            itemForDrop = new Pants(ItemType.Legendary);
                            break;
                        case 6:
                            itemForDrop = new Sword(ItemType.Legendary);
                            break;
                        default:
                            itemForDrop = null;
                            break;
                    }

                    break;
                case EnemyType.Caesar:
                    itemForDrop = new Sword(ItemType.Legendary);
                    break;
                default:
                    itemForDrop = null;
                    break;
            }

            return itemForDrop;
        }

        public override int GetAttackDemage()
        {
            int damage = this.Attack - Field.Hero.Defence;
            if (damage < 0)
            {
                damage = 10;
            }

            return damage;
        }

        public override string ToString()
        {
            const int MaxCellSize = 13;
            var enemiestLeft = 3 - BattleField.AttackedEnemies[this.EnemyType];

            string outputEnemyType = this.EnemyType.ToString();
            string outputGold = "Gold: " + this.Gold;
            string outputAttack = "Attack: " + this.Attack;
            string outputDefence = "Defence: " + this.Defence;
            string outputHealth = "Health: " + this.Health;
            string outputEnemiesLeft = string.Empty;

            if (this.EnemyType != EnemyType.Caesar)
            {
                outputEnemiesLeft = "Left: " + enemiestLeft;
            }

            string enemyTypePadding = new string(' ', MaxCellSize - outputEnemyType.Length);
            string goldPadding = new string(' ', MaxCellSize - outputGold.Length);
            string attackPadding = new string(' ', MaxCellSize - outputAttack.Length);
            string defencePadding = new string(' ', MaxCellSize - outputDefence.Length);
            string healthPadding = new string(' ', MaxCellSize - outputHealth.Length);

            return string.Format(
                "{0} {1} {2} {3} {4} {5}",
                outputEnemyType + enemyTypePadding,
                outputGold + goldPadding,
                outputAttack + attackPadding,
                outputDefence + defencePadding,
                outputHealth + healthPadding,
                outputEnemiesLeft);
        }
    }
}