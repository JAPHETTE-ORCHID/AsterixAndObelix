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
        private Hero mainHero;
        private Dictionary<string, IItem> items = new Dictionary<string, IItem>(); 

        protected Engine()
        {
            
        }

        public void CommandHandler(string line)
        {
            // add hero Asterix name;
            // add item Common heroName
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
                            string heroName = lineSplit[3];
                            AddHero(heroType, heroName);
                            break;

                        case "item":
                            string itemType = lineSplit[2];
                            string addTo = lineSplit[3];
                            AddItem(itemType, addTo);
                            break;
                    }
                    break;
            }
        }

        public void AddItem(string type, string addTo)
        {
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
                item = new Belt(100, ItemType.Common, 100);
            }
            else if (type.Equals(boots))
            {
                item = new Boots(100, ItemType.Common, 100);
            }
            else if (type.Equals(chest))
            {
                item = new Chest(100, ItemType.Common, 100);
            }
            else if (type.Equals(helmet))
            {
                item = new Helmet(100, ItemType.Common, 100);
            }
            else if (type.Equals(pants))
            {
                item = new Pants(100, ItemType.Common, 100);
            }
            else if (type.Equals(sword))
            {
                item = new Sword(100, ItemType.Common, 100);
            }
            else
            {
                throw new IndexOutOfRangeException("Item not found.");
            }

            items.Add(addTo, item);
        }

        public void AddHero(string type, string name)
        {
            string obelix = HeroType.Asterix.ToString().ToLower();
            string asterix = HeroType.Obelix.ToString().ToLower();
            type = type.ToLower();

            if (type.Equals(obelix))
            {
                this.mainHero = new Obelix(name, 100, 100, 100);
            }
            else if (type.Equals(asterix))
            {
                // TODO: add hero asterix
            }
        }
    }
}