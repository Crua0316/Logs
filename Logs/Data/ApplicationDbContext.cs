using Microsoft.EntityFrameworkCore;
using Logs.Models;

namespace Logs.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EventLog> EventLogs { get; set; }
    }
}

