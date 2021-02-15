using ExcelParser.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExcelParser.Domain.Repository
{
    public class SpreadsheetDbContext : DbContext
    {
        public DbSet<Row> Rows { get; set; }

        public SpreadsheetDbContext(DbContextOptions<SpreadsheetDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
