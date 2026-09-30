// Student nr      : 225094388;225024254;222078921
// Programmer name : Zenande Silinga; Phiwe Bunu; Rethabile Mosoeu
// Assignment nr   : Practical Assessment 2
// Purpose         : Stores the request identifier used by the default error view.

namespace BoardAppDB.Models
{
    public class ErrorViewModel
    {
        //
        // Name             : property string? RequestId
        // Purpose          : Stores the identifier of the current request for diagnostics
        // Re-use           : None
        // Input Parameter  : string? value
        //                    - request identifier value
        // Output Type      : string?
        //                    - stored request identifier
        //
        public string? RequestId { get; set; } // end property RequestId

        //
        // Name             : property bool ShowRequestId
        // Purpose          : Indicates whether a request identifier is available to display
        // Re-use           : RequestId
        // Input Parameter  : bool value
        //                    - read-only calculated value
        // Output Type      : bool
        //                    - true when RequestId contains a value
        //
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); // end property ShowRequestId
    } // end class ErrorViewModel
} // end namespace BoardAppDB.Models
