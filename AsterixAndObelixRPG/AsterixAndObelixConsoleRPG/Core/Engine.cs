using System;
using System.Threading;
using AsterixAndObelixConsoleRPG.Models.Players;

namespace AsterixAndObelixConsoleRPG.Core
{
    public class Engine
    {
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
                    }
            }
        }

        public void AddHero(string type, string name)
        {
            
        }
    }
}