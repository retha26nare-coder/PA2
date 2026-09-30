// Student nr      : 225094388;225024254;222078921
// Programmer name : Zenande Silinga; Phiwe Bunu; Rethabile Mosoeu
// Assignment nr   : Practical Assessment 2
// Purpose         : Defines the operation used to create and seed the Board database.

namespace BoardAppDB.Interfaces
{
    public interface IDBInitializer
    {
        //
        // Name             : void Initialize()
        // Purpose          : Creates the database and seeds it when the Board table is empty
        // Re-use           : None
        // Method Parameters: None
        // Output Type      : void
        //
        void Initialize();
    } // end interface IDBInitializer
} // end namespace BoardAppDB.Interfaces
