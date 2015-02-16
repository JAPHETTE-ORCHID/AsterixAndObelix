namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;

    internal class Enemy : PlayerObject, IDrop
    {
        private EnemyType enemyType;

        public void DropRandomItem()
        {
            throw new System.NotImplementedException();
        }

        public void DropGold()
        {
            throw new System.NotImplementedException();
        }
    }
}