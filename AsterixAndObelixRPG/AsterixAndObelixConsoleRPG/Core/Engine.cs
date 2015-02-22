namespace AsterixAndObelixConsoleRPG.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;
    using AsterixAndObelixConsoleRPG.Models.Fields;
    using AsterixAndObelixConsoleRPG.Models.Items.AttackItems;
    using AsterixAndObelixConsoleRPG.Models.Items.DefenseItems;
    using AsterixAndObelixConsoleRPG.Models.Players;
    
    public class Engine
    {
        public void CommandHandler(string line)
        {
            string[] lineSplit = line.Split(' ');
            string comand = lineSplit[0];

            switch (comand)
            {
                case "add":
                    string type = lineSplit[1];

                    switch (type)
                    {
                        case "hero":
                            string heroType = lineSplit[2];
                            this.AddHero(heroType);
                            break;

                        case "item":
                            string itemType = lineSplit[2];
                            this.AddItem(itemType);
                            break;

                        default:
                            Console.WriteLine("Invalid command");
                            break;
                    }

                    break;
                case "attack":
                    string target = lineSplit[1];

                    switch (target)
                    {
                        case "cadet":                          
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        case "manipularius":             
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        case "tribune":                           
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        case "centurion":                            
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        case "caesar":                            
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        default:
                            Console.Error.WriteLine("Cannot see enemy.");
                            break;
                    }

                    break;
                case "battlefield":
                    this.GenerateEnemies();
                    Console.WriteLine(BattleField.PrintBattleField());
                    break;
                case "info":
                    Console.WriteLine(BattleField.PrintBattleField());
                    break;
                case "exit":
                    this.ExitGame();
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }

        protected void AddItem(string type)
        {
            if (BattleField.Hero == null)
            {
                throw new ApplicationException("You should add hero first.");
            }

            string belt = AllItems.Belt.ToString().ToLower();
            string boots = AllItems.Boots.ToString().ToLower();
            string chest = AllItems.Chest.ToString().ToLower();
            string helmet = AllItems.Helmet.ToString().ToLower();
            string pants = AllItems.Pants.ToString().ToLower();
            string sword = AllItems.Sword.ToString().ToLower();
            type = type.ToLower();
            IItem item;

            if (type.Equals(belt))
            {
                item = new Belt(ItemType.Common);
                Field.Hero.Attack += ((AttackItem) item).Attack;
            }
            else if (type.Equals(boots))
            {
                item = new Boots(ItemType.Common);
                Field.Hero.Attack += ((AttackItem) item).Attack;
            }
            else if (type.Equals(chest))
            {
                item = new Chest(ItemType.Common);
                Field.Hero.Defence += ((DefenseItem) item).Defence;
            }
            else if (type.Equals(helmet))
            {
                item = new Helmet(ItemType.Common);
                Field.Hero.Defence += ((DefenseItem)item).Defence;
            }
            else if (type.Equals(pants))
            {
                item = new Pants(ItemType.Common);
                Field.Hero.Defence += ((DefenseItem)item).Defence;
            }
            else if (type.Equals(sword))
            {
                item = new Sword(ItemType.Common);
                Field.Hero.Attack += ((AttackItem)item).Attack;
            }
            else
            {
                throw new IndexOutOfRangeException("Item not found");
            }

            BattleField.Hero.Inventory.AddItem(item);
            Console.WriteLine("New item added");
        }

        protected void AddHero(string type)
        {
            if (BattleField.Hero != null)
            {
                throw new Exception("The hero was already created.");
            }

            string obelix = HeroType.Obelix.ToString().ToLower();
            string asterix = HeroType.Asterix.ToString().ToLower();
            type = type.ToLower();

            if (type.Equals(obelix))
            {
                BattleField.Hero = new Obelix();
                Console.WriteLine("Obelix added");
            }
            else if (type.Equals(asterix))
            {
                BattleField.Hero = new Asterix();
                Console.WriteLine("Asterix added");
            }
            else
            {
                Console.WriteLine("Hero type " + type + " is invalid. Choose between these:");
                var values = Enum.GetValues(typeof(HeroType));
                foreach (var hero in values)
                {
                    Console.WriteLine("-" + hero);
                }
            }
        }

        protected void GenerateEnemies()
        {           
            BattleField.Enemies = new List<Enemy>()
            {
                new Enemy(50, 50, 50, EnemyType.Cadet, 50),
                new Enemy(60, 60, 60, EnemyType.Manipularius, 60),
                new Enemy(75, 75, 70, EnemyType.Tribune, 75),
                new Enemy(90, 90, 90, EnemyType.Centurion, 90),
                new Enemy(100, 100, 100, EnemyType.Caesar, 100)
            };
        }

        protected void AttackEnemy(string type)
        {              
            string typeForCast = type.Substring(0, 1).ToUpper() + type.Substring(1);
            EnemyType enemyType = (EnemyType)Enum.Parse(typeof(EnemyType), typeForCast);
            foreach (var enemy in BattleField.Enemies)
            {
                if (enemy.EnemyType == enemyType)
                {
                    BattleField.TargetEnemy = enemy;
                }
            }
            
            int enemyHealth = BattleField.TargetEnemy.Health;
            int heroHealth = BattleField.Hero.Health;
            bool isAlive = true;
            while (isAlive)
            {               
                enemyHealth -= BattleField.Hero.MakeAttack();               
                heroHealth -= BattleField.TargetEnemy.MakeAttack();
                if (enemyHealth <= 0)
                {
                    BattleField.Hero.Gold += BattleField.TargetEnemy.Gold;
                    BattleField.Hero.Experience += 100;
                    IItem droppedItem = BattleField.TargetEnemy.DropRandomItem();
                    IItem weakItem = null;
                    bool hasInventoryItem = false;
                    foreach (var item in BattleField.Hero.Inventory.Items)
                    {
                        if (item.GetType().Name == droppedItem.GetType().Name)
                        {
                            hasInventoryItem = true;
                            int numDroppedItemType = (int)droppedItem.ItemType;
                            int numCurrentItemType = (int)item.ItemType;
                            if (numDroppedItemType > numCurrentItemType)
                            {
                                weakItem = item;
                            }                                         
                        }                        
                    }

                    if (weakItem != null)
                    {
                        BattleField.Hero.Inventory.RemoveItem(weakItem);
                        hasInventoryItem = false;
                    }

                    if (!hasInventoryItem)
                    {
                        BattleField.Hero.Inventory.AddItem(droppedItem);
                    }
                                              
                    Console.WriteLine(BattleField.Hero.GetType().Name + " slain " + BattleField.TargetEnemy.EnemyType);
                    isAlive = false;
                }
                else
                {
                    Console.WriteLine(BattleField.Hero.GetType().Name + " die");
                    isAlive = false;
                }
            }
        }

        private void ExitGame()
        {
            Console.WriteLine("Good bye!");
            Thread.Sleep(1000);
            Game.IsGameRunning = false;
        }
    }
}