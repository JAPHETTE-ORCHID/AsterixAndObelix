namespace AsterixAndObelixConsoleRPG.Models.Players
{
    internal class Obelix : Hero
    {
        private const int StartAttack = 90;
        private const int StartDefence = 150;
        private const int StartHealth = 100;

        public Obelix()
            : base(StartAttack, StartDefence, StartHealth)
        {   
        }
    }
}