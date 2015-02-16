using System;
using System.Threading;
using AsterixAndObelixConsoleRPG.Models.Players;
using AsterixAndObelixConsoleRPG.Enumerations;

namespace AsterixAndObelixConsoleRPG.Core
{
    public class Engine
    {
        private Hero mainHero;

        protected Engine()
        {
            
        }

        public void CommandHandler(string line)
        {
            // add hero Asterix name;
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
                    }
                    break;
            }
        }

        public void AddHero(string type, string name)
        {
            string obelix = HeroType.Asterix.ToString().ToLower();
            string asterix = HeroType.Obelix.ToString().ToLower();

            if (type.ToLower().Equals(obelix))
            {
                this.mainHero = new Obelix(name, 100, 100, 100);
            }
            else if (type.ToLower().Equals(asterix))
            {
                // TODO: add hero asterix
            }
        }
    }
}