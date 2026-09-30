// Student nr      : 225094388;225024254;222078921
// Programmer name : Zenande Silinga; Phiwe Bunu; Rethabile Mosoeu
// Assignment nr   : Practical Assessment 2
// Purpose         : Defines the repository operations available for Board records.

using BoardAppDB.Models;

namespace BoardAppDB.Interfaces
{
    public interface IBoard
    {
        //
        // Name             : IEnumerable<Board> GetBoards()
        // Purpose          : Retrieves a collection of Boards.
        // Re-use           : None
        // Method Parameters: None
        // Output Type      : IEnumerable<Board>
        //                    - the current collection of boards
        //
        IEnumerable<Board> GetBoards();

        //
        // Name             : Board Details(string boardCode)
        // Purpose          : Retrieves details of a board based on its board code.
        // Re-use           : None
        // Method Parameters: string boardCode
        //                    - the unique board code of the board to retrieve details for
        // Output Type      : Board
        //                    - the board matching the supplied code
        //
        Board Details(string boardCode);

        //
        // Name             : Board Create(Board board)
        // Purpose          : Creates a new board entry.
        // Re-use           : None
        // Method Parameters: Board board
        //                    - the Board object representing the new board to be created
        // Output Type      : Board
        //                    - the created board
        //
        Board Create(Board board);

        //
        // Name             : Board Edit(Board board)
        // Purpose          : Edits an existing board entry.
        // Re-use           : None
        // Method Parameters: Board board
        //                    - the Board object representing the modified board
        // Output Type      : Board
        //                    - the updated board
        //
        Board Edit(Board board);

        //
        // Name             : bool Delete(Board board)
        // Purpose          : Deletes an existing board entry.
        // Re-use           : None
        // Method Parameters: Board board
        //                    - the Board object representing the board to be deleted
        // Output Type      : bool
        //                    - true if deletion was successful, otherwise false
        //
        bool Delete(Board board);

        //
        // Name             : bool IsExist(string boardCode)
        // Purpose          : Checks if a board with the specified board code exists.
        // Re-use           : None
        // Method Parameters: string boardCode
        //                    - the board code to check for existence
        // Output Type      : bool
        //                    - true if the board exists, otherwise false
        //
        bool IsExist(string boardCode);
    } // end interface IBoard
} // end namespace BoardAppDB.Interfaces
