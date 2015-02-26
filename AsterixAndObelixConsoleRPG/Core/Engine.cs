namespace AsterixAndObelixConsoleRPG.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Contracts;
    using CustomExceptions;
    using Enumerations;
    using Models.Fields;
    using Models.Players;
  
    public class Engine
    {
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
                            break;
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
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        case Constants.ManipulariusCommand:             
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        case Constants.TribuneCommand:                           
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        case Constants.CenturionCommand:                            
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        case Constants.OrdinatusCommand:                            
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        case Constants.CaesarCommand:
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        default:
                            throw new InvalidEnemyException("Cannot find requested enemy.");
                            break;
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
                case Constants.ExitCommand:
                    this.ExitGame();
                    break;
                default:
                    throw new InputException("Invalid command.");
            }
        }

        protected void AddHero(string type)
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
                Console.WriteLine("Obelix added");
            }
            else if (type.Equals(asterix))
            {
                Field.Hero = new Asterix();
                Console.WriteLine("Asterix added");
            }
            else
            {
                throw new InputException("You have to choise between asterix and obelix.");
            }
        }

        protected void GenerateEnemies()
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

        protected void AttackEnemy(string type)
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
                enemyHealth -= Field.Hero.MakeAttack();               
                heroHealth -= BattleField.TargetEnemy.MakeAttack();
                Field.Hero.Health -= BattleField.TargetEnemy.MakeAttack();

                if (heroHealth <= 0)
                {
                    Console.WriteLine(Field.Hero.GetType().Name + " die");
                    isAlive = false;
                    this.ExitGame();
                }
                else if (enemyHealth <= 0)
                {
                    if (BattleField.TargetEnemy.EnemyType != EnemyType.Caesar)
                    {
                        Field.Hero.Gold += BattleField.TargetEnemy.Gold;
                        Field.Hero.Experience += BattleField.TargetEnemy.Expirience;
                        if (Field.Hero.Experience % 300 == 0)
                        {
                            Field.Hero.Level++;
                        }

                        IItem droppedItem = BattleField.TargetEnemy.DropRandomItem();
                        Field.Hero.Inventory.AddItem(droppedItem);
                    }

                    Console.WriteLine(Field.Hero.GetType().Name + " slain " + BattleField.TargetEnemy.EnemyType);
                    isAlive = false;

                    if (BattleField.TargetEnemy.EnemyType == EnemyType.Caesar)
                    {
                        Console.WriteLine("You Win The Game.");
                        this.ExitGame();
                    }
                }
            }
        }

        private void ExitGame()
        {
            Console.WriteLine("Game Over!");
            Thread.Sleep(1000);
            Game.IsGameRunning = false;
        }
    }
}