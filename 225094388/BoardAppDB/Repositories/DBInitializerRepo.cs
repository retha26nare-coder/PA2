// Student nr      : 225094388;225024254;222078921
// Programmer name : Zenande Silinga; Phiwe Bunu; Rethabile Mosoeu
// Assignment nr   : Practical Assessment 2
// Purpose         : Creates the Board database and seeds the required ten boards once.

using BoardAppDB.Data;
using BoardAppDB.Interfaces;
using BoardAppDB.Models;

namespace BoardAppDB.Repositories
{
    public class DBInitializerRepo : IDBInitializer
    {
        private readonly BoardContext context;

        public DBInitializerRepo(BoardContext context)
        {
            //
            // Name             : DBInitializerRepo(BoardContext context)
            // Purpose          : Constructor receiving the database context through dependency injection
            // Re-use           : None
            // Method Parameters: BoardContext context
            //                    - the EF Core context used to create and seed the database
            // Output Type      : None
            //
            this.context = context;
        } // end method DBInitializerRepo

        public void Initialize()
        {
            //
            // Name             : void Initialize()
            // Purpose          : Creates the database and seeds the ten required boards when the table is empty
            // Re-use           : BoardContext
            // Method Parameters: None
            // Output Type      : void
            //
            context.Database.EnsureCreated();

            if (!context.Boards.Any())
            {
                var boards = new List<Board>()
            {
                new Board("1001", "Espressif", "ESP32-WROOM-32", 4096, 129.00m),
                new Board("1002", "Espressif", "ESP32-C3-MINI-1", 4096, 99.00m),
                new Board("1003", "STMicroelectronics", "STM32F103C8T6", 64, 75.00m),
                new Board("1004", "STMicroelectronics", "STM32F411CEU6", 512, 145.00m),
                new Board("1005", "Microchip", "ATmega328P", 32, 89.00m),
                new Board("1006", "Microchip", "ATmega2560", 256, 199.00m),
                new Board("1007", "WCH", "CH32V003F4P6", 16, 29.00m),
                new Board("1008", "Raspberry Pi", "Pico", 2048, 89.00m),
                new Board("1009", "Espressif", "ESP-01S", 1024, 65.00m),
                new Board("1010", "CUTfree", "CV32-BFN-01", 128, 49.00m)
            };

                foreach (Board board in boards)
                {
                    context.Boards.Add(board);
                } // end foreach

                context.SaveChanges();
            } // end if
        } // end method Initialize
    } // end class DBInitializerRepo
} // end namespace BoardAppDB.Repositories
