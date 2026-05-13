using System.Collections.Generic;

namespace AddressBook
{
    public interface IDataSource
    {
        //UC-18 Save all address books
        void Save(Dictionary<string, List<AddressBook>> addressBooks);

        //UC-18 Load all address books
        Dictionary<string, List<AddressBook>> Load();
    }
}