using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterixAndObelixConsoleRPG.Models.Players
{
    class Asterix : Hero
    {
        public Asterix(string name, int attack, int defence, int health)
            : base (name, attack, defence, health)
        {   
        }
    }
}
