// Student nr      : 225094388;225024254;222078921
// Programmer name : Zenande Silinga; Phiwe Bunu; Rethabile Mosoeu
// Assignment nr   : Practical Assessment 2
// Purpose         : Handles the home page, privacy page and error page for BoardAppDB.

using System.Diagnostics;
using BoardAppDB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BoardAppDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            //
            // Name             : HomeController(ILogger<HomeController> logger)
            // Purpose          : Constructor that stores the injected logger
            // Re-use           : None
            // Method Parameters: ILogger<HomeController> logger
            //                    - logger supplied by dependency injection
            // Output Type      : None
            //
            this.logger = logger;
        } // end method HomeController

        public IActionResult Index()
        {
            //
            // Name             : IActionResult Index()
            // Purpose          : Displays the home page
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : IActionResult
            //                    - the default Index view
            //
            IActionResult result = View();
            return result;
        } // end method Index

        public IActionResult Privacy()
        {
            //
            // Name             : IActionResult Privacy()
            // Purpose          : Displays the privacy policy page
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : IActionResult
            //                    - the default Privacy view
            //
            IActionResult result = View();
            return result;
        } // end method Privacy

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            //
            // Name             : IActionResult Error()
            // Purpose          : Displays the error page with the current request trace identifier
            // Re-use           : None
            // Method Parameters: None
            // Output Type      : IActionResult
            //                    - the default Error view with an ErrorViewModel
            //
            IActionResult result = View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            return result;
        } // end method Error
    } // end class HomeController
} // end namespace BoardAppDB.Controllers
