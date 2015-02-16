namespace AsterixAndObelixConsoleRPG.Models.Players
{
    public abstract class Hero : PlayerObject
    {
        private int experience;
        private int gold;

        public Hero(int attack, int defence, int health)
            : base (attack, defence, health)
        {
            
        }

        public int Level
        {
            get { return experience; }
        }
    }
}