using System;
using AsterixAndObelixConsoleRPG.Enumerations;

namespace AsterixAndObelixConsoleRPG.Models.Players
{
    public static class EnemyFactory
    {
        public static Enemy Enemy(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Cadet:
                    return new Enemy(140, 80, 50, EnemyType.Cadet, 150);
                case EnemyType.Manipularius:
                    return new Enemy(430, 400, 60, EnemyType.Manipularius, 350);
                case EnemyType.Tribune:
                    return new Enemy(800, 750, 75, EnemyType.Tribune, 650);
                case EnemyType.Centurion:
                    return new Enemy(1400, 1300, 85, EnemyType.Centurion, 1000);
                case EnemyType.Ordinatus:
                    return new Enemy(2050, 2050, 100, EnemyType.Ordinatus, 1500);
                case EnemyType.Caesar:
                    return new Enemy(3500, 3500, 1000, EnemyType.Caesar, 1000);
                default:
                    throw new Exception("Invalid enemy type");
            }
        }
    }
}
