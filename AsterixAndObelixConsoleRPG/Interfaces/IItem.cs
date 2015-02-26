namespace AsterixAndObelixConsoleRPG.Interafaces
{
    using AsterixAndObelixConsoleRPG.Enumerations;

    public interface IItem
    {
        int Price
        {
            get;
        }

        ItemType ItemType
        {
            get;
            set;
        }
    }
}