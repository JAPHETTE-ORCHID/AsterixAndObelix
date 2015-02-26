using AsterixAndObelixConsoleRPG.CustomExceptions;

namespace AsterixAndObelixConsoleRPG.Models.Players
{
    using System;
    using AsterixAndObelixConsoleRPG.Enumerations;

    public static class EnemyFactory
    {
        public static Enemy Enemy(EnemyType type)
        {
            switch (type)
            {
                case EnemyType.Cadet:
                    return new Enemy(140, 80, 50, EnemyType.Cadet, 200);
                case EnemyType.Manipularius:
                    return new Enemy(430, 400, 60, EnemyType.Manipularius, 1000);
                case EnemyType.Tribune:
                    return new Enemy(600, 500, 75, EnemyType.Tribune, 2000);
                case EnemyType.Centurion:
                    return new Enemy(730, 680, 85, EnemyType.Centurion, 3000);
                case EnemyType.Ordinatus:
                    return new Enemy(870, 830, 100, EnemyType.Ordinatus, 4000);
                case EnemyType.Caesar:
                    return new Enemy(100000, 100000, 1000, EnemyType.Caesar, 10000);
                default:
                    throw new InputException("Invalid enemy type");
            }
        }
    }
}
