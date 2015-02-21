namespace AsterixAndObelixConsoleRPG.Contracts
{
    using AsterixAndObelixConsoleRPG.Enumerations;

    public interface IItem
    {
        decimal Price
        {
            get;
            set;
        }

        ItemType ItemType
        {
            get;
            set;
        }
    }
}