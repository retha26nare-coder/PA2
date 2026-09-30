// Student nr      : 225094388;225024254;222078921
// Programmer name : Zenande Silinga; Phiwe Bunu; Rethabile Mosoeu
// Assignment nr   : Practical Assessment 2
// Purpose         : Handles listing, viewing, creating, editing and deleting boards through the repository.

using BoardAppDB.Interfaces;
using BoardAppDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardAppDB.Controllers
{
    public class BoardController : Controller
    {
        private readonly IBoard repository;

        public BoardController(IBoard repository)
        {
            //
            // Name             : BoardController(IBoard repository)
            // Purpose          : Constructor receiving the Board repository through dependency injection
            // Re-use           : None
            // Method Parameters: IBoard repository
            //                    - repository used to perform Board operations
            // Output Type      : None
            //
            this.repository = repository;
        } // end method BoardController

        public IActionResult Index()
        {
            //
            // Name             : IActionResult Index()
            // Purpose          : Returns the Index view with the current list of Board objects
            // Re-use           : GetBoards()
            // Method Parameters: None
            // Output Type      : IActionResult
            //                    - the Index view containing all boards
            //
            IActionResult result = View(repository.GetBoards());
            return result;
        } // end method Index

        public IActionResult Details(string boardCode)
        {
            //
            // Name             : IActionResult Details(string boardCode)
            // Purpose          : Returns the Details view for the board identified by boardCode
            // Re-use           : Details()
            // Method Parameters: string boardCode
            //                    - unique board code of the board to display
            // Output Type      : IActionResult
            //                    - the Details view containing the selected board
            //
            Board board = repository.Details(boardCode);
            IActionResult result = View(board);
            return result;
        } // end method Details

        [HttpGet]
        public IActionResult Create()
        {
            //
            // Name             : IActionResult Create()
            // Purpose          : Returns the Create view and shows the Add button
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : IActionResult
            //                    - the default Create view
            //
            ViewBag.ShowAdd = true;
            IActionResult result = View();
            return result;
        } // end method Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("BoardCode,Make,Model,FlashKb,Price")] Board board)
        {
            //
            // Name             : IActionResult Create(Board board)
            // Purpose          : Validates and creates a new board, rejecting duplicate board codes
            // Re-use           : IsExist(), Create()
            // Method Parameters: Board board
            //                    - board populated from the submitted Create form
            // Output Type      : IActionResult
            //                    - the Create view with validation or success information
            //
            ViewBag.ShowAdd = true;

            if (ModelState.IsValid)
            {
                if (repository.IsExist(board.BoardCode))
                {
                    ModelState.AddModelError("BoardCode", "A board with that board code already exists.");
                }
                else
                {
                    repository.Create(board);
                    ViewBag.SuccessMessage = $"Board {board.BoardCode} was added.";
                    ViewBag.ShowAdd = false;
                } // end if
            } // end if

            IActionResult result = View(board);
            return result;
        } // end method Create

        [HttpGet]
        public IActionResult Edit(string boardCode)
        {
            //
            // Name             : IActionResult Edit(string boardCode)
            // Purpose          : Retrieves the selected board and returns the Edit view
            // Re-use           : Details()
            // Method Parameters: string boardCode
            //                    - unique board code of the board to edit
            // Output Type      : IActionResult
            //                    - the Edit view containing the selected board
            //
            Board board = repository.Details(boardCode);
            ViewBag.ShowSave = true;
            IActionResult result = View(board);
            return result;
        } // end method Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string boardCode, [Bind("Make,Model,FlashKb,Price")] Board board)
        {
            //
            // Name             : IActionResult Edit(string boardCode, Board board)
            // Purpose          : Validates and updates the selected board while protecting its board code
            // Re-use           : Edit()
            // Method Parameters: string boardCode
            //                    - board code identifying the existing board
            //                    Board board
            //                    - edited values posted by the form, excluding BoardCode
            // Output Type      : IActionResult
            //                    - the Edit view with validation or success information
            //
            board.BoardCode = boardCode;
            ModelState.Remove("BoardCode");
            ViewBag.ShowSave = true;

            if (ModelState.IsValid)
            {
                repository.Edit(board);
                ViewBag.SuccessMessage = $"Board {board.BoardCode} was updated.";
                ViewBag.ShowSave = false;
            } // end if

            IActionResult result = View(board);
            return result;
        } // end method Edit

        [HttpGet]
        public IActionResult Delete(string boardCode)
        {
            //
            // Name             : IActionResult Delete(string boardCode)
            // Purpose          : Retrieves the selected board and returns the Delete confirmation view
            // Re-use           : Details()
            // Method Parameters: string boardCode
            //                    - unique board code of the board to delete
            // Output Type      : IActionResult
            //                    - the Delete view containing the selected board
            //
            Board board = repository.Details(boardCode);
            ViewBag.ShowDelete = true;
            IActionResult result = View(board);
            return result;
        } // end method Delete

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string boardCode, Board board)
        {
            //
            // Name             : IActionResult Delete(string boardCode, Board board)
            // Purpose          : Deletes the board only when the supplied board code identifies an existing board
            // Re-use           : Details(), Delete()
            // Method Parameters: string boardCode
            //                    - board code posted by the hidden form field
            //                    Board board
            //                    - posted Board object containing the form values
            // Output Type      : IActionResult
            //                    - the Delete view containing the board and result message
            //
            Board existingBoard = repository.Details(boardCode);
            ViewBag.ShowDelete = true;

            if (existingBoard != null)
            {
                repository.Delete(existingBoard);
                ViewBag.SuccessMessage = $"Board {boardCode} was deleted.";
                ViewBag.ShowDelete = false;
                board = existingBoard;
            } // end if

            IActionResult result = View(board);
            return result;
        } // end method Delete
    } // end class BoardController
} // end namespace BoardAppDB.Controllers
