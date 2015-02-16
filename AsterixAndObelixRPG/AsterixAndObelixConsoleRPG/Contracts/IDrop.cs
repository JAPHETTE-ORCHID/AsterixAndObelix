namespace AsterixAndObelixConsoleRPG.Contracts
{
    public interface IDrop
    {
        IItem DropRandomItem();

        int DropGold();
    }
}