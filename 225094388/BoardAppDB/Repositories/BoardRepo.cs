// Student nr      : 225094388;225024254;222078921
// Programmer name : Zenande Silinga; Phiwe Bunu; Rethabile Mosoeu
// Assignment nr   : Practical Assessment 2
// Purpose         : Repository implementation that performs CRUD operations against the Board database.

using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Models;

namespace BoardAppDB.Repositories
{
    public class BoardRepo : IBoard
    {
        private readonly BoardContext context;

        public BoardRepo(BoardContext context)
        {
            //
            // Name             : BoardRepo(BoardContext context)
            // Purpose          : Constructor receiving the database context through dependency injection
            // Re-use           : None
            // Method Parameters: BoardContext context
            //                    - the EF Core context used for Board database operations
            // Output Type      : None
            //
            this.context = context;
        } // end method BoardRepo

        public IEnumerable<Board> GetBoards()
        {
            //
            // Name             : IEnumerable<Board> GetBoards()
            // Purpose          : Retrieves all boards from the Board table
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : IEnumerable<Board>
            //                    - all boards stored in the database
            //
            IEnumerable<Board> boards = context.Boards.ToList();
            return boards;
        } // end method GetBoards

        public Board Details(string boardCode)
        {
            //
            // Name             : Board Details(string boardCode)
            // Purpose          : Retrieves one board using its board code
            // Re-use           : None
            // Method Parameters: string boardCode
            //                    - unique code of the board to retrieve
            // Output Type      : Board
            //                    - board matching the supplied code
            //
            Board board = context.Boards.Find(boardCode)!;
            return board;
        } // end method Details

        public Board Create(Board board)
        {
            //
            // Name             : Board Create(Board board)
            // Purpose          : Adds a new board to the database
            // Re-use           : None
            // Method Parameters: Board board
            //                    - board object to add
            // Output Type      : Board
            //                    - the board that was added
            //
            context.Boards.Add(board);
            context.SaveChanges();
            return board;
        } // end method Create

        public Board Edit(Board board)
        {
            //
            // Name             : Board Edit(Board board)
            // Purpose          : Updates an existing board in the database
            // Re-use           : None
            // Method Parameters: Board board
            //                    - board object containing the updated values
            // Output Type      : Board
            //                    - the updated board
            //
            context.Boards.Update(board);
            context.SaveChanges();
            return board;
        } // end method Edit

        public bool Delete(Board board)
        {
            //
            // Name             : bool Delete(Board board)
            // Purpose          : Deletes an existing board from the database
            // Re-use           : None
            // Method Parameters: Board board
            //                    - board object identifying the board to delete
            // Output Type      : bool
            //                    - true when the board was deleted, otherwise false
            //
            bool result = false;
            Board? existingBoard = context.Boards.Find(board.BoardCode);

            if (existingBoard != null)
            {
                context.Boards.Remove(existingBoard);
                context.SaveChanges();
                result = true;
            } // end if

            return result;
        } // end method Delete

        public bool IsExist(string boardCode)
        {
            //
            // Name             : bool IsExist(string boardCode)
            // Purpose          : Checks whether a board code already exists in the database
            // Re-use           : None
            // Method Parameters: string boardCode
            //                    - board code to check
            // Output Type      : bool
            //                    - true when a matching board exists, otherwise false
            //
            bool result = context.Boards.Any(b => b.BoardCode == boardCode);
            return result;
        } // end method IsExist
    } // end class BoardRepo
} // end namespace BoardAppDB.Repositories
