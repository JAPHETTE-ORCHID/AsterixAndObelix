namespace AsterixAndObelixConsoleRPG.Core
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using CustomExceptions;
    using Enumerations;
    using Models.Fields;
    using Models.Helper;
    using Models.Players;

    public class Engine
    {
        public static void ExitGame(ExitGameReason reason)
        {
            switch (reason)
            {
                case ExitGameReason.ExitCommand:
                    Console.WriteLine("Good Bye.");
                    break;
                case ExitGameReason.PlayerDie:
                    Console.WriteLine("You Die. Game Over!");
                    break;
                case ExitGameReason.PlayerWinTheGame:
                    Console.WriteLine("Congratulations! You Win.");
                    break;
            }

            Thread.Sleep(500);
            Game.IsGameRunning = false;
        }

        public void CommandHandler(string line)
        {
            string[] lineSplit = line.Split(' ');
            string comand = lineSplit[0];

            switch (comand)
            {
                case Constants.AddComand:
                    if (lineSplit.Length < 2 || lineSplit[1] == string.Empty)
                    {
                        throw new InputException("You must add hero.");
                    }

                    string type = lineSplit[1].ToLower();

                    switch (type)
                    {
                        case Constants.HeroCommand:
                            if (lineSplit.Length < 3 || lineSplit[2] == string.Empty)
                            {
                                throw new InputException("You have to choise between asterix and obelix.");
                            }

                            string heroType = lineSplit[2];
                            this.AddHero(heroType);
                            break;
                        default:
                            throw new InputException("Critical error when adding hero.");
                    }

                    break;
                case Constants.BattleFieldCommand:
                    this.GenerateEnemies();
                    Console.WriteLine(BattleField.PrintBattleField());
                    break;
                case Constants.AttackCommand:
                    if (lineSplit.Length < 2 || lineSplit[1] == string.Empty)
                    {
                        throw new InputException("Cannot attack the air.");
                    }

                    string target = lineSplit[1].ToLower();

                    switch (target)
                    {
                        case Constants.CadetCommand:                          
                            Field.Hero.AttackEnemy(lineSplit[1]);
                            break;
                        case Constants.ManipulariusCommand:
                            Field.Hero.AttackEnemy(lineSplit[1]);
                            break;
                        case Constants.TribuneCommand:
                            Field.Hero.AttackEnemy(lineSplit[1]);
                            break;
                        case Constants.CenturionCommand:
                            Field.Hero.AttackEnemy(lineSplit[1]);
                            break;
                        case Constants.OrdinatusCommand:
                            Field.Hero.AttackEnemy(lineSplit[1]);
                            break;
                        case Constants.CaesarCommand:
                            Field.Hero.AttackEnemy(lineSplit[1]);
                            break;
                        default:
                            throw new InvalidEnemyException("Cannot find requested enemy.");
                    }

                    break;                
                case Constants.InfoCommand:
                    Console.WriteLine(Field.PrintHero());
                    break;
                case Constants.MarketFieldCommand:
                    MarketField market = new MarketField();
                    market.PrintAllItemTypes();
                    market.ReadCommand();
                    break;
                case Constants.CheatCommand:
                    Field.Hero.Health += 100000;
                    Field.Hero.Defence += 100000;
                    Field.Hero.Attack += 100000;
                    break;
                case Constants.ClearCommand:
                    Console.Clear();
                    break;
                case Constants.HelpCommand:
                    Helper.DrawAllCommands();
                    break;
                case Constants.ExitCommand:
                    ExitGame(ExitGameReason.ExitCommand);
                    break;
                default:
                    throw new InputException("Invalid command.");
            }
        }

        private void AddHero(string type)
        {
            if (Field.Hero != null)
            {
                throw new InputException("Hero allready exists. Proceed with battle.");
            }

            string obelix = HeroType.Obelix.ToString().ToLower();
            string asterix = HeroType.Asterix.ToString().ToLower();
            type = type.ToLower();

            if (type.Equals(obelix))
            {
                Field.Hero = new Obelix();
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("You have create new hero Obelix.");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("1.For continue playing please enter command \"help\" to show you all command.");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("2.For exit the game enter command \"exit\".");
                Console.WriteLine();
            }
            else if (type.Equals(asterix))
            {
                Field.Hero = new Asterix();
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("You have create new hero Asterix.");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("1.For continue playing please enter command \"help\" to show you all command.");
                Console.WriteLine("-------------------------------------------------------------------------------");
                Console.WriteLine("2.For exit the game enter command \"exit\".");
                Console.WriteLine();
            }
            else
            {
                throw new InputException("You have to choise between asterix and obelix.");
            }
        }

        private void GenerateEnemies()
        {
            Validator.CheckIfHeroExist(Field.Hero);
            BattleField.Enemies = new List<Enemy>();
            bool isAllEnemiesAreKilled = true;

            if (BattleField.AttackedEnemies[EnemyType.Cadet] < 3)
            {
                BattleField.Enemies.Add(EnemyFactory.Enemy(EnemyType.Cadet));
                isAllEnemiesAreKilled = false;
            }

            if (BattleField.AttackedEnemies[EnemyType.Manipularius] < 3)
            {
                BattleField.Enemies.Add(EnemyFactory.Enemy(EnemyType.Manipularius));
                isAllEnemiesAreKilled = false;
            }

            if (BattleField.AttackedEnemies[EnemyType.Tribune] < 3)
            {
                BattleField.Enemies.Add(EnemyFactory.Enemy(EnemyType.Tribune));
                isAllEnemiesAreKilled = false;
            }

            if (BattleField.AttackedEnemies[EnemyType.Centurion] < 3)
            {
                BattleField.Enemies.Add(EnemyFactory.Enemy(EnemyType.Centurion));
                isAllEnemiesAreKilled = false;
            }

            if (BattleField.AttackedEnemies[EnemyType.Ordinatus] < 3)
            {
                BattleField.Enemies.Add(EnemyFactory.Enemy(EnemyType.Ordinatus));
                isAllEnemiesAreKilled = false;
            }

            if (isAllEnemiesAreKilled)
            {
                BattleField.Enemies.Add(EnemyFactory.Enemy(EnemyType.Caesar));
            }
        }
    }
}