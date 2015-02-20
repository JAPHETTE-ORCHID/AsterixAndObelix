namespace AsterixAndObelixConsoleRPG.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;
    using AsterixAndObelixConsoleRPG.Models.Fields;
    using AsterixAndObelixConsoleRPG.Models.Items;
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
                item = new Belt(100, 100, ItemType.Common);
            }
            else if (type.Equals(boots))
            {
                item = new Boots(100, 100, ItemType.Common);
            }
            else if (type.Equals(chest))
            {
                item = new Chest(100, 100, ItemType.Common);
            }
            else if (type.Equals(helmet))
            {
                item = new Helmet(100, 100, ItemType.Common);
            }
            else if (type.Equals(pants))
            {
                item = new Pants(100, 100, ItemType.Common);
            }
            else if (type.Equals(sword))
            {
                item = new Sword(100, 100, ItemType.Common);
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
                new Enemy(10, 10, 10, EnemyType.Cadet, 100),
                new Enemy(20, 20, 20, EnemyType.Manipularius, 200),
                new Enemy(30, 30, 30, EnemyType.Tribune, 300),
                new Enemy(40, 40, 40, EnemyType.Centurion, 400),
                new Enemy(50, 50, 50, EnemyType.Caesar, 500)
            };
            Console.WriteLine("Enemies added");
        }

        private void ExitGame()
        {
            Console.WriteLine("Good bye!");
            Thread.Sleep(1000);
            Game.IsGameRunning = false;
        }
    }
}