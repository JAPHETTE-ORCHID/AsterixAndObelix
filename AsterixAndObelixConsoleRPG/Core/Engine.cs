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
                case "add":
                    if (lineSplit.Length < 2 || lineSplit[1] == string.Empty)
                    {
                        throw new InputException("You must add hero.");
                    }

                    string type = lineSplit[1].ToLower();

                    switch (type)
                    {
                        case "hero":
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
                case "battle":
                    this.GenerateEnemies();
                    Console.WriteLine(BattleField.PrintBattleField());
                    break;
                case "attack":
                    if (lineSplit.Length < 2 || lineSplit[1] == string.Empty)
                    {
                        throw new InputException("Cannot attack the air.");
                    }

                    string target = lineSplit[1].ToLower();

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
                        case "ordinatus":                            
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        case "caesar":
                            this.AttackEnemy(lineSplit[1]);
                            break;
                        default:
                            throw new InvalidEnemyException("Cannot find requested enemy.");
                            break;
                    }

                    break;                
                case "info":
                    Console.WriteLine(Field.PrintHero());
                    break;
                case "market":
                    MarketField market = new MarketField();
                    market.PrintAllItemTypes();
                    market.ReadCommand();
                    break;
                case "iamnakov":
                    Field.Hero.Health += 100000;
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "exit":
                    this.ExitGame();
                    break;
                default:
                    throw new InputException("Invalid command.");
                    break;
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
                BattleField.Enemies.Add(new Enemy(140, 80, 50, EnemyType.Cadet, 150));
                isAllEnemiesAreKilled = false;
            }

            if (BattleField.AttackedEnemies[EnemyType.Manipularius] < 3)
            {
                BattleField.Enemies.Add(new Enemy(430, 400, 60, EnemyType.Manipularius, 350));
                isAllEnemiesAreKilled = false;
            }

            if (BattleField.AttackedEnemies[EnemyType.Tribune] < 3)
            {
                BattleField.Enemies.Add(new Enemy(800, 750, 75, EnemyType.Tribune, 650));
                isAllEnemiesAreKilled = false;
            }

            if (BattleField.AttackedEnemies[EnemyType.Centurion] < 3)
            {
                BattleField.Enemies.Add(new Enemy(1400, 1300, 85, EnemyType.Centurion, 1000));
                isAllEnemiesAreKilled = false;
            }

            if (BattleField.AttackedEnemies[EnemyType.Ordinatus] < 3)
            {
                BattleField.Enemies.Add(new Enemy(2050, 2050, 100, EnemyType.Ordinatus, 1500));
                isAllEnemiesAreKilled = false;
            }

            if (isAllEnemiesAreKilled)
            {
                BattleField.Enemies.Add(new Enemy(3500, 3500, 1000, EnemyType.Caesar, 1000));
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