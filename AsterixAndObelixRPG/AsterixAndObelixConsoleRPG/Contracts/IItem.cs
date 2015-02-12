namespace AsterixAndObelixConsoleRPG.Contracts
{
    using AsterixAndObelixConsoleRPG.Enumerations;

    public interface IItem
    {
        int Price
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