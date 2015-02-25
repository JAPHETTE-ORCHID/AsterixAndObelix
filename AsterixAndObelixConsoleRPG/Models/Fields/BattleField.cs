﻿namespace AsterixAndObelixConsoleRPG.Models.Fields
{
    using System.Collections.Generic;
    using System.Text;

    using Enumerations;
    using Players;

    public class BattleField : Field
    {
        public static Dictionary<EnemyType, int> AttackedEnemies = new Dictionary<EnemyType, int>()
        {
            { EnemyType.Cadet, 0 },
            { EnemyType.Manipularius, 0 },
            { EnemyType.Centurion, 0 },
            { EnemyType.Tribune, 0 },
            { EnemyType.Ordinatus, 0 },
            { EnemyType.Caesar, 0 }
        };

        private static IList<Enemy> enemies;
        private static Enemy targetEnemy;
        
        public static IList<Enemy> Enemies
        {
            get
            {
                return BattleField.enemies;
            }

            set
            {
                BattleField.enemies = value;
            }
        }

        public static Enemy TargetEnemy
        {
            get
            {
                return BattleField.targetEnemy;
            }

            set
            {
                BattleField.targetEnemy = value;
            }
        }

        public static string PrintBattleField()
        {
            StringBuilder printBattleField = new StringBuilder();

            string printHero = PrintHero();
            printBattleField.Append(printHero);
            printBattleField.AppendLine();
            printBattleField.AppendLine("Enemies: ");

            if (BattleField.Enemies != null && BattleField.Enemies.Count > 0)
            {
                foreach (var enemy in BattleField.Enemies)
                {
                    printBattleField.AppendLine(enemy.ToString());
                }
            }
            else
            {
                printBattleField.AppendLine("No enimies.");
            }

            return printBattleField.ToString();
        }
    }
}