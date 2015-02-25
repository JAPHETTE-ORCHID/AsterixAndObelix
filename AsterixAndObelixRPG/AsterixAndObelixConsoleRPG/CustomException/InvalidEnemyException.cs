namespace AsterixAndObelixConsoleRPG.CustomException
{
    using System;

    class InvalidEnemyException : Exception
    {
        public InvalidEnemyException(string message)
            : base(message)
        {
        }

        public override string Message
        {
            get { return base.Message + " Try another enemy."; }
        }
    }
}
