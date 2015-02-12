namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;

    public class Enemy : PlayerObject, IDrop
    {
        private EnemyType enemyType;
    }
}