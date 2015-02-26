namespace AsterixAndObelixConsoleRPG.Models.Fields
{
    using System;
    using System.Collections.Generic;

    using CustomExceptions;
    using Interafaces;
    using Players;

    public static class Validator
    {
        public static void CheckForNegativeNumber(decimal num)
        {
            if (num < 0)
            {
                throw new ArgumentOutOfRangeException("Field \"Number\" cannot be a negative number.");
            }
        }

        public static void CheckForEmptyOrNull(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Text field cannot be empty or null.");
            }
        }

        public static void CheckForNullItem(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null.");
            }
        }

        public static void CheckForNullInventory(Inventory inventory)
        {
            if (inventory == null)
            {
                throw new ArgumentNullException("Inventory cannot be null.");
            }
        }

        public static void CheckIfHeroExist(Hero hero)
        {
            if (Field.Hero == null)
            {
                throw new InputException("You must add hero first.");
            }
        }

        public static void CheckIfEnemiesExist(IList<Enemy> enemies)
        {
            if (enemies == null)
            {
                throw new InputException("You must call the battle first.");
            }
        }
    }
}