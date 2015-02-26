namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using System;
    using System.Linq;
    using System.Text;

    using Core;
    using CustomExceptions;
    using Enumerations; 
    using Fields;
    using Interafaces;
    using Items.AttackItems;
    using Items.DefenseItems;
    using Items.UniqueItem;      

    public delegate void EventHandler();

    public abstract class Hero : PlayerObject
    {
        private int experience;
        private int kills;
        private int gold;
        private Inventory inventory;      

        protected Hero(int attack, int defence, int health)
            : base(attack, defence, health)
        {
            this.inventory = new Inventory();
            this.Level = 1;
        }

        public static event EventHandler WatchOut;

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

        public int Kills { get; private set; }

        public int Gold
        {
            get
            {
                return 1000;// this.gold;
            }

            set
            {
                Validator.CheckForNegativeNumber(value);
                this.gold = value;
            }
        }

        public int Level { get; set; }

        public Inventory Inventory
        {
            get
            {
                return this.inventory;
            }

            set
            {
                Validator.CheckForNullInventory(value);
                this.inventory = value;
            }
        }

        public static void Warning()
        {
            Console.WriteLine("Watch out! You almost die!");
        }

        public string ShowItems()
        {
            StringBuilder result = new StringBuilder();

            result.Append("Items: ")
                  .Append(string.Join(", ", this.Inventory));

            return result.ToString();
        }

        public void AddPowerFromItem(IItem item)
        {
            if (item is DefenseItem)
            {
                this.Defence += ((DefenseItem)item).Defence;
            }
            else if (item is AttackItem)
            {
                this.Attack += ((AttackItem)item).Attack;
            }
            else if (item is DefenceAttack)
            {
                this.Attack += ((DefenceAttack)item).Attack;
                this.Defence += ((DefenceAttack)item).Defence;
            }
        }

        public void RemovePowerFromItem(IItem item)
        {
            if (item is DefenseItem)
            {
                this.Defence -= ((DefenseItem)item).Defence;
            }
            else if (item is AttackItem)
            {
                this.Attack -= ((AttackItem)item).Attack;
            }
            else if (item is DefenceAttack)
            {
                this.Attack -= ((DefenceAttack)item).Attack;
                this.Defence -= ((DefenceAttack)item).Defence;
            }
        }

        public void AttackEnemy(string type)
        {
            Validator.CheckIfHeroExist(Field.Hero);
            Validator.CheckIfEnemiesExist(BattleField.Enemies);
            string typeForCast = type.Substring(0, 1).ToUpper() + type.Substring(1);
            EnemyType enemyType = (EnemyType)Enum.Parse(typeof(EnemyType), typeForCast);
            if (BattleField.AttackedEnemies[enemyType] >= 3)
            {
                throw new InvalidEnemyException("This enemies are dead.");
            }

            BattleField.TargetEnemy = BattleField.Enemies.Single(enemy => enemy.EnemyType == enemyType);
            if (BattleField.AttackedEnemies.ContainsKey(enemyType))
            {
                BattleField.AttackedEnemies[enemyType]++;
            }

            int enemyHealth = BattleField.TargetEnemy.Health;
            int heroHealth = Field.Hero.Health;
            bool isAlive = true;

            while (isAlive)
            {
                enemyHealth -= this.GetAttackDemage();
                heroHealth -= BattleField.TargetEnemy.GetAttackDemage();
                this.Health -= BattleField.TargetEnemy.GetAttackDemage();              

                if (heroHealth <= 0)
                {
                    isAlive = false;
                    Engine.ExitGame(ExitGameReason.PlayerDie);
                }
                else if (enemyHealth <= 0)
                {
                    if (BattleField.TargetEnemy.EnemyType != EnemyType.Caesar)
                    {
                        Field.Hero.Gold += BattleField.TargetEnemy.Gold;
                        Field.Hero.Experience += BattleField.TargetEnemy.Expirience;
                        Field.Hero.Kills++;
                        if (Field.Hero.Kills == 1 || Field.Hero.Kills == 2)
                        {
                            Field.Hero.Experience -= BattleField.TargetEnemy.Expirience / 2;             
                        }

                        if (Field.Hero.Experience % 300 == 0)
                        {
                            Field.Hero.Level++;
                        }                            

                        IItem droppedItem = BattleField.TargetEnemy.DropRandomItem();
                        this.AddItem(droppedItem);
                    }

                    Console.WriteLine(Field.Hero.GetType().Name + " successfully kill " + BattleField.TargetEnemy.EnemyType);
                    if (Field.Hero.Health < 50)
                    {
                        WatchOut = Warning;
                        WatchOut.Invoke();
                    }

                    isAlive = false;

                    if (BattleField.TargetEnemy.EnemyType == EnemyType.Caesar)
                    {
                        Engine.ExitGame(ExitGameReason.PlayerWinTheGame);
                    }
                }
            }
        }

        public override int GetAttackDemage()
        {
            int damage = this.Attack - BattleField.TargetEnemy.Defence;
            if (damage <= 0)
            {
                damage = 10;
            }

            return damage;
        }

        public void AddItem(IItem item)
        {
            Validator.CheckForNullItem(item);
            int sameTypeIndex = this.Inventory.SameTypeIndex(item);
            if (sameTypeIndex == -1)
            {
                this.AddPowerFromItem(item);
            }
            else
            {
                this.ReplaceItem(sameTypeIndex, item);
            }

            this.Inventory.Items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            Validator.CheckForNullItem(item);
            this.RemovePowerFromItem(item);
            this.Inventory.Items.Remove(item);
        }

        public void ReplaceItem(int position, IItem item)
        {
            IItem oldItem = this.Inventory.Items[position];
            this.RemovePowerFromItem(oldItem);
            this.Inventory.Items.Remove(oldItem);
            this.AddPowerFromItem(item);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("-------------------------------------------------------------------------------");
            result.Append("Hero: ").AppendLine(this.GetType().Name);
            result.AppendLine("-------------------------------------------------------------------------------");
            result.Append("Level: ").AppendLine(this.Level.ToString());
            result.AppendLine("-------------------------------------------------------------------------------");
            result.Append("Experience: ").AppendLine(this.Experience.ToString());
            result.AppendLine("-------------------------------------------------------------------------------");
            result.Append("Gold: ").AppendLine(this.Gold.ToString());
            result.AppendLine("-------------------------------------------------------------------------------");
            result.Append("Attack: ").AppendLine(this.Attack.ToString());
            result.AppendLine("-------------------------------------------------------------------------------");
            result.Append("Defence: ").AppendLine(this.Defence.ToString());
            result.AppendLine("-------------------------------------------------------------------------------");
            result.Append("Health: ").AppendLine(this.Health.ToString());
            result.AppendLine("-------------------------------------------------------------------------------");
            result.Append("Inventory: ");
            if (this.Inventory.Items.Count > 0)
            {
                result.AppendLine();
                this.Inventory.Items.ForEach(i => result.AppendLine(i.ToString()));
            }
            else
            {
                result.AppendLine("No items.");
            }

            return result.ToString();
        }
    }
}