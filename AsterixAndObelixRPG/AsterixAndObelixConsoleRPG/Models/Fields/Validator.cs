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
    }
}
