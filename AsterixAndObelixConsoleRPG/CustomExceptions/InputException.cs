namespace AsterixAndObelixConsoleRPG.CustomExceptions
{
    using System;

    public class InputException : Exception
    {
        public InputException(string message)
            : base(message)
        {
        }

        public override string Message
        {
            get { return base.Message + " Try again."; }
        }
    }
}
