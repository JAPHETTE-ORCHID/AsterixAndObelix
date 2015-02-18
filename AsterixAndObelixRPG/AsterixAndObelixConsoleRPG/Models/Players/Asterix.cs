using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterixAndObelixConsoleRPG.Models.Players
{
    class Asterix : Hero
    {
        private const int Attack = 150;
        private const int Defence = 90;
        private const int Health = 100;

        public Asterix()
            : base(Attack, Defence, Health)
        {   
        }
    }
}
