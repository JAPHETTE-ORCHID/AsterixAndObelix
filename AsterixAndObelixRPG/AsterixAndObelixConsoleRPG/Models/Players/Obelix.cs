namespace AsterixAndObelixConsoleRPG.Models.Players
{
    internal class Obelix : Hero
    {
        private const int Attack = 90;
        private const int Defence = 150;
        private const int Health = 100;

        public Obelix()
            : base(Attack, Defence, Health)
        {   
        }
    }
}