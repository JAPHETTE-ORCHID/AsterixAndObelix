namespace AsterixAndObelixConsoleRPG.Contracts
{
    internal interface IAttack
    {
        int Attack
        {
            get;
            set;
        }

        void MakeAttack();
    }
}