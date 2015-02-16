namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using AsterixAndObelixConsoleRPG.Contracts;
    using AsterixAndObelixConsoleRPG.Enumerations;

    public class Enemy : PlayerObject, IDrop
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