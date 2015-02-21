namespace AsterixAndObelixConsoleRPG.Models.Fields
{
    using System.Collections.Generic;
    using System.Text;
    using AsterixAndObelixConsoleRPG.Models.Players;

    public class BattleField : Field
    {
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
            printBattleField.AppendLine();
            printBattleField.AppendLine(BattleField.Hero.ToString());
            printBattleField.AppendLine();
            foreach (var enemy in BattleField.Enemies)
            {
                printBattleField.AppendLine(enemy.ToString());
            }

            return printBattleField.ToString();
        }
    }
}