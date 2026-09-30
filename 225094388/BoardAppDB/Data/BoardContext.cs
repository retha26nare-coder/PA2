// Student nr      : 225094388;225024254;222078921
// Programmer name : Zenande Silinga; Phiwe Bunu; Rethabile Mosoeu
// Assignment nr   : Practical Assessment 2
// Purpose         : Entity Framework Core database context for the Board database.

using BoardAppDB.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardAppDB.Data
{
    public class BoardContext : DbContext
    {
        public BoardContext(DbContextOptions<BoardContext> options) : base(options)
        {
            //
            // Name             : BoardContext(DbContextOptions<BoardContext> options)
            // Purpose          : Constructor receiving database configuration through dependency injection
            // Re-use           : Base DbContext constructor
            // Method Parameters: DbContextOptions<BoardContext> options
            //                    - EF Core database configuration options
            // Output Type      : None
            //
        } // end method BoardContext

        //
        // Name             : property DbSet<Board> Boards
        // Purpose          : Provides access to Board records in the database
        // Re-use           : None
        // Input Parameter  : DbSet<Board> value
        //                    - database set supplied by Entity Framework Core
        // Output Type      : DbSet<Board>
        //                    - collection representing the Board table
        //
        public DbSet<Board> Boards { get; set; } // end property Boards

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            // Name             : void OnModelCreating(ModelBuilder modelBuilder)
            // Purpose          : Configures the Board table and the Price conversion used by SQLite
            // Re-use           : Entity Framework Core model-building pipeline
            // Method Parameters: ModelBuilder modelBuilder
            //                    - builder used to configure the EF Core model
            // Output Type      : void
            //
            modelBuilder.Entity<Board>().ToTable("Board");
            modelBuilder.Entity<Board>()
                .Property(b => b.Price)
                .HasConversion<double>();
        } // end method OnModelCreating
    } // end class BoardContext
} // end namespace BoardAppDB.Data
