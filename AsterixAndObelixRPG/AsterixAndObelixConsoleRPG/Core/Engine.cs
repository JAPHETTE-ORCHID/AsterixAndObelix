﻿namespace AsterixAndObelixConsoleRPG.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    using Contracts;
    using Enumerations;
    using Models.Fields;
    using Models.Items.AttackItems;
    using Models.Items.DefenseItems;
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
                    string type = lineSplit[1];

                    switch (type)
                    {
                        case "hero":
                            string heroType = lineSplit[2];
                            this.AddHero(heroType);
                            break;

                        default:
                            Console.WriteLine("Invalid command");
                            break;
                    }

                    break;
                case "attack":
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
                            Console.Error.WriteLine("Cannot see enemy.");
                            break;
                    }

                    break;
                case "battle":
                    this.GenerateEnemies();
                    Console.WriteLine(BattleField.PrintBattleField());
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
                    Field.Hero.Defence += 100000;
                    Field.Hero.Attack += 100000;
                    Field.Hero.Health += 100000;
                    break;
                case "exit":
                    this.ExitGame();
                    break;
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }

        protected void AddHero(string type)
        {
            if (Field.Hero != null)
            {
                throw new Exception("The hero was already created.");
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
            BattleField.Enemies = new List<Enemy>() {};
            bool isAllEnemiesAreKilled = true;

            if (BattleField.attackedEnemies[EnemyType.Cadet] < 3)
            {
                BattleField.Enemies.Add(new Enemy(120, 120, 50, EnemyType.Cadet, 150));
                isAllEnemiesAreKilled = false;
            }
            if (BattleField.attackedEnemies[EnemyType.Manipularius] < 3)
            {
                BattleField.Enemies.Add(new Enemy(430, 400, 60, EnemyType.Manipularius, 350));
                isAllEnemiesAreKilled = false;
            }
            if (BattleField.attackedEnemies[EnemyType.Tribune] < 3)
            {
                BattleField.Enemies.Add(new Enemy(800, 750, 75, EnemyType.Tribune, 650));
                isAllEnemiesAreKilled = false;
            }
            if (BattleField.attackedEnemies[EnemyType.Centurion] < 3)
            {
                BattleField.Enemies.Add(new Enemy(1400, 1300, 85, EnemyType.Centurion, 1000));
                isAllEnemiesAreKilled = false;
            }
            if (BattleField.attackedEnemies[EnemyType.Ordinatus] < 3)
            {
                BattleField.Enemies.Add(new Enemy(2050, 2050, 100, EnemyType.Ordinatus, 1500));
                isAllEnemiesAreKilled = false;
            }

            if (isAllEnemiesAreKilled)
            {
                BattleField.Enemies.Add(new Enemy(1000, 1000, 1000, EnemyType.Caesar, 1000));
            }
        }

        protected void AttackEnemy(string type)
        {              
            string typeForCast = type.Substring(0, 1).ToUpper() + type.Substring(1);
            EnemyType enemyType = (EnemyType)Enum.Parse(typeof(EnemyType), typeForCast);
            if (BattleField.attackedEnemies[enemyType] >= 3)
            {
                throw new Exception("Invalid enemy");
            }
            BattleField.TargetEnemy = BattleField.Enemies.Single(enemy => enemy.EnemyType == enemyType);

            if (BattleField.attackedEnemies.ContainsKey(enemyType))
            {
                BattleField.attackedEnemies[enemyType]++;
            }

            int enemyHealth = BattleField.TargetEnemy.Health;
            int heroHealth = Field.Hero.Health;
            bool isAlive = true;

            while (isAlive)
            {
                enemyHealth -= Field.Hero.MakeAttack();               
                heroHealth -= BattleField.TargetEnemy.MakeAttack();
                Field.Hero.Health -= BattleField.TargetEnemy.MakeAttack();

                if(heroHealth <= 0)
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