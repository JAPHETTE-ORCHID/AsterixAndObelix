using System;

namespace AsterixAndObelixConsoleRPG.Models.Players
{
    class Obelix : Hero
    {
        private const int Attack = 50;
        private const int Defence = 150;
        private const int Health = 100;

        public Obelix()
            : base(Attack, Defence, Health)
        {   
        }
    }
}