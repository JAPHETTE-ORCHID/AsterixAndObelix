using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsterixAndObelixConsoleRPG.Contracts
{
    public interface IInventory
    {
        void AddItem(IItem item);

        void RemoveItem(IItem item);

        string ShowItems();
    }
}
