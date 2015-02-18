using System;
using System.Collections.Generic;
using System.Threading;
using AsterixAndObelixConsoleRPG.Contracts;
using AsterixAndObelixConsoleRPG.Models.Players;
using AsterixAndObelixConsoleRPG.Enumerations;
using AsterixAndObelixConsoleRPG.Models.Items;

namespace AsterixAndObelixConsoleRPG.Core
{
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
                            AddHero(heroType);
                            break;

                        case "item":
                            string itemType = lineSplit[2];
                            AddItem(itemType);
                            break;
                        default:
                            Console.WriteLine("Invalid command");
                            break;
                    }
                    break;
                case "info":
                    Console.WriteLine(PlayerInfo.Show());
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
            if (PlayerInfo.Hero == null)
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

            PlayerInfo.Hero.Inventory.AddItem(item);
            Console.WriteLine("New item added");
        }

        protected void AddHero(string type)
        {
            if (PlayerInfo.Hero != null)
            {
                throw new Exception("The hero was already created.");
            }

            string obelix = HeroType.Obelix.ToString().ToLower();
            string asterix = HeroType.Asterix.ToString().ToLower();
            type = type.ToLower();

            if (type.Equals(obelix))
            {
                PlayerInfo.Hero = new Obelix(100, 100, 100);
                Console.WriteLine("Obelix added");
            }
            else if (type.Equals(asterix))
            {
                PlayerInfo.Hero = new Asterix(100, 100, 100);
                Console.WriteLine("Asterix added");
            }
            else
            {
                Console.WriteLine("Hero type " + type + " is invalid. Choose between these:");
                var values = Enum.GetValues(typeof(HeroType));
                foreach (var hero in values)
                {
                    Console.WriteLine("-"+hero);
                }
            }
        }

        private void ExitGame()
        {
            Console.WriteLine("Good bye!");
            Thread.Sleep(1000);
            Game.isGameRunning = false;
        }
    }
}