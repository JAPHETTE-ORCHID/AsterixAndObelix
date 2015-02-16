namespace AsterixAndObelixConsoleRPG.Models.Fields
{
    using System;

    public static class Validator
    {
        public static void CheckForNegativeNumber(int num)
        {
            if (num < 0)
            {
                throw new ArgumentOutOfRangeException("Field \"Number\" cannot be a negative number.");
            }
        }

        public static void CheckForEmptyOrNull(string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Text field cannot be empty or null.");
            }
        }
    }
}