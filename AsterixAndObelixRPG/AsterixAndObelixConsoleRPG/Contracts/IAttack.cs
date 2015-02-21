namespace AsterixAndObelixConsoleRPG.Contracts
{
    internal interface IAttack
    {
        int Attack
        {
            get;
            set;
        }

        int MakeAttack();
    }
}