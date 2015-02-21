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

                        case "enemies":                           
                            this.GenerateEnemies();
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
            }
            else if (type.Equals(boots))
            {
                item = new Boots(ItemType.Common);
            }
            else if (type.Equals(chest))
            {
                item = new Chest(ItemType.Common);
            }
            else if (type.Equals(helmet))
            {
                item = new Helmet(ItemType.Common);
            }
            else if (type.Equals(pants))
            {
                item = new Pants(ItemType.Common);
            }
            else if (type.Equals(sword))
            {
                item = new Sword(ItemType.Common);
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
                new Enemy(100, 100, 100, EnemyType.Cadet, 100),
                new Enemy(200, 200, 200, EnemyType.Manipularius, 200),
                new Enemy(300, 300, 300, EnemyType.Tribune, 300),
                new Enemy(400, 400, 400, EnemyType.Centurion, 400),
                new Enemy(500, 500, 500, EnemyType.Caesar, 500)
            };
            Console.WriteLine("Enemies added");
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
            
            Console.WriteLine(BattleField.Hero.GetType().Name + " attack " + BattleField.TargetEnemy.EnemyType);
            Console.WriteLine("Hero Damage: " + BattleField.Hero.MakeAttack());
            Console.WriteLine("Enemy Damage: " + BattleField.TargetEnemy.MakeAttack());
        }

        private void ExitGame()
        {
            Console.WriteLine("Good bye!");
            Thread.Sleep(1000);
            Game.IsGameRunning = false;
        }
    }
}