namespace AsterixAndObelixConsoleRPG.Models.Fields
{
    using System;

    using AsterixAndObelixConsoleRPG.Contracts;

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
    }
}